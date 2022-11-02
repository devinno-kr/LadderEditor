using Devinno.PLC.Ladder;
using Devinno.PLC.Interface;
using LadderEditor.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LadderEditor.Managers
{
    public class LibraryManager
    {
        #region Properties
        public List<LadderDll> References { get; } = new List<LadderDll>();
        public Dictionary<string, List<VReference>> Classes { get; } = new Dictionary<string, List<VReference>>();
        #endregion

        #region Constructor
        public LibraryManager()
        {
            LoadLibrary();
        }
        #endregion

        #region Method
        #region UploadLibrary
        public void UploadLibrary(string path)
        {
            var dir = Path.GetDirectoryName(path);
            var libName = Path.GetFileName(path);
            var files = Directory.GetFiles(dir).Where(x => Path.GetExtension(x).ToLower() == ".dll").ToList();

            var mkdir = Path.Combine(Application.StartupPath, "LadderLibraries", libName);
            if (!Directory.Exists(mkdir)) Directory.CreateDirectory(mkdir);

            foreach (var file in files)
            {
                var fn = Path.GetFileName(file);
                if (fn != "Devinno.PLC.dll" && fn != "Devinno.PLC.Library.dll")
                {
                    File.Copy(file, Path.Combine(mkdir, Path.GetFileName(file)), true);

                    var xml = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".xml");
                    if (File.Exists(xml))
                        File.Copy(xml, Path.Combine(mkdir, Path.GetFileName(xml)), true);
                }
            }

            LoadLibrary();

        }
        #endregion
        #region LoadLibrary
        public void LoadLibrary()
        {
            References.Clear();
            Classes.Clear();

            var dirlib = Path.Combine(Application.StartupPath, "LadderLibraries");

            foreach (var dir in Directory.GetDirectories(dirlib))
            {
                var s = Path.Combine(dir, Path.GetFileName(dir));
                if (File.Exists(s))
                {

                    var vref = DllTool.Load(Path.Combine(dir, Path.GetFileName(dir)), (asm, tp, vref, vlib) =>
                    {
                        try
                        {
                            XmlDocument doc = null;
                            if (File.Exists(Path.Combine(dir, Path.GetFileNameWithoutExtension(dir) + ".xml")))
                            {
                                try
                                {
                                    doc = new XmlDocument();
                                    doc.Load(Path.Combine(dir, Path.GetFileNameWithoutExtension(dir) + ".xml"));
                                }
                                catch { doc = null; }
                            }

                            Classes.Add(vlib.Name, new List<VReference>());

                            var vsm = new List<string>();
                            var vsp = new List<string>();

                            vsm.AddRange(typeof(object).GetMethods().Where(m => m.IsPublic && !m.IsSpecialName).Select(x => x.Name));
                            vsp.AddRange(typeof(object).GetProperties().Where(m => m.DeclaringType != null && m.DeclaringType.IsPublic).Select(x => x.Name));

                            foreach (var m in tp.GetProperties())
                            {
                                if (m.DeclaringType != null && m.DeclaringType.IsPublic && !vsp.Contains(m.Name) && m.Name != "LibraryName")
                                {
                                    var vv = new VReference { Text = m.Name, ImageIndex = 11 };
                                    Classes[vlib.Name].Add(vv);

                                    if (doc != null)
                                    {
                                        try
                                        {
                                            var s = "P:" + vlib.TypeName + "." + m.Name;
                                            var v = doc["doc"]["members"];
                                            var nd = v.ChildNodes.Cast<XmlNode>().Where(x => x.Attributes["name"].InnerText == s).FirstOrDefault();
                                            if (nd != null)
                                                vv.Desc = string.Concat(nd["summary"].InnerText.Split("\r\n").Select(x => x.Trim() + "\r\n")).Trim();
                                        }
                                        catch { }
                                    }
                                }
                            }
                            foreach (var m in tp.GetMethods())
                            {
                                if (m.IsPublic && !m.IsSpecialName && !vsm.Contains(m.Name) && !(m.Name == "Begin" && m.GetParameters().Count() == 0)
                                                                                            && !(m.Name == "End" && m.GetParameters().Count() == 0))
                                {
                                    var vv = new VReference { Text = m.Name, ImageIndex = 8 };
                                    Classes[vlib.Name].Add(vv);

                                    if (doc != null)
                                    {
                                        try
                                        {
                                            var sParam = "";
                                            foreach (var param in m.GetParameters()) sParam += param.ParameterType.ToString() + ",";
                                            if (sParam.Length > 0) sParam = sParam.Substring(0, sParam.Length - 1);

                                            var s = "M:" + vlib.TypeName + "." + m.Name + (string.IsNullOrEmpty(sParam) ? "" : "(" + sParam + ")");
                                            var v = doc["doc"]["members"];
                                            var nd = v.ChildNodes.Cast<XmlNode>().Where(x => x.Attributes["name"].InnerText == s).FirstOrDefault();
                                            if (nd != null)
                                                vv.Desc = string.Concat(nd["summary"].InnerText.Split("\r\n").Select(x => x.Trim() + "\r\n")).Trim();
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                        catch { }
                    });

                    if (vref != null) References.Add(vref);

                }
            }
        }
        #endregion
        #endregion
    }

    #region class : VReference
    public class VReference
    {
        public string Text { get; set; }
        public int ImageIndex { get; set; }
        public string Desc { get; set; }
    }
    #endregion
}
