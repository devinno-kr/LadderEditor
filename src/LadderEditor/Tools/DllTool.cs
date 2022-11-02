using Devinno.PLC.Interface;
using Devinno.PLC.Ladder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace LadderEditor.Tools
{
    public class DllTool
    {
        #region class : DllALC
        class DllALC : AssemblyLoadContext
        {
            private string file;
            private AssemblyDependencyResolver resolver;

            public DllALC(string file) : base(true)
            {
                this.file = file;
                this.resolver = new AssemblyDependencyResolver(file);

                this.Resolving += (o, s) =>
                {
                    var path = resolver.ResolveAssemblyToPath(s);

                    if(path != null && File.Exists(path))
                    {
                        Assembly ret = null;
                        var bytes = File.ReadAllBytes(path);
                        using (var ms = new MemoryStream(bytes)) ret = LoadFromStream(ms);
                        return ret;
                    }
                    else return null;
                };
            }
        }
        #endregion

        #region Load
        public static LadderDll Load(string file, Action<Assembly, Type, LadderDll, LadderLibrary> act)
        {
            LadderDll ret = null;
            try
            {
                #region Reference
                var vref = new LadderDll
                {
                    DllPath = Path.GetFileName(file),
                    Binaries = new Dictionary<string, byte[]>(),
                    Libraries = new List<LadderLibrary>()
                };

                foreach (var dll in Directory.GetFiles(Path.GetDirectoryName(file)))
                    vref.Binaries.Add(Path.GetFileName(dll), File.ReadAllBytes(dll));
                #endregion

                Assembly asm = null;
                var ALC = new DllALC(file);
                
                var bytes = File.ReadAllBytes(file);
                using (var ms = new MemoryStream(bytes)) asm = ALC.LoadFromStream(ms);
                
                if (asm != null)
                {
                    foreach (var tp in asm.GetTypes())
                    {
                        var lib = tp.GetInterface("Devinno.PLC.Library.ILadderLibrary");
                        if (lib != null && !tp.IsAbstract && tp.IsClass)
                        {
                            var v = asm.CreateInstance(tp.FullName) as ILadderLibrary;
                            #region Library
                            var vlib = new LadderLibrary
                            {
                                Name = v?.LibraryName ?? tp.Name,
                                TypeName = tp.FullName,
                                DllPath = Path.GetFileName(file),
                                InstanceName = "",
                            };

                            vref.Libraries.Add(vlib);
                            #endregion

                            act(asm, tp, vref, vlib);
                        }
                    }
                }

                ALC.Unload();

                ret = vref;
            }
            catch(Exception ex) { }
            return ret;
        }
        #endregion
    }
}
