using Devinno.Data;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;
using Devinno.Tools;
using LadderEditor.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LadderEditor.Forms
{
    public partial class FormConnect : DvForm
    {
        #region Const
        const string Path_ConnList = "connlist.json";
        #endregion

        #region Member Variable
        #endregion

        #region Constructor
        public FormConnect()
        {
            InitializeComponent();

            #region Buttons 
            btnPM.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            btnPM.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            #endregion

            #region tree.NodeClick
            tree.SelectionMode = ItemSelectionMode.Single;
            tree.NodeClicked += (o, s) => { if (s.Node.Tag is ConnItem) inAddr.Value = ((ConnItem)s.Node.Tag).Address; };
            #endregion
            #region btnSearch.ButtonClick
            btnSearch.ButtonClick += (o, s) =>
            {
                var str = Devinno.Tools.NetworkTool.GetLocalIP();
                if (str != null)
                {
                    var strs = str.Split('.');
                    if (strs.Length == 4)
                    {
                        var ret = UdpTool.SendReceive(7898, string.Format("{0}.{1}.{2}.255", strs[0], strs[1], strs[2]), 7897, "FB");
                        var lstConn = GetConnectionItems();

                        tree.Nodes.Clear();

                        foreach (var v in lstConn)
                            tree.Nodes.Add(new DvTreeViewLabelNode(v.Name + " - " + v.Address) { Tag = v });

                        if (ret != null)
                            foreach (var k in ret.Keys)
                                tree.Nodes.Add(new DvTreeViewLabelNode(k) { Tag = new ConnItem() { Name = "Unknown", Address = k } });

                        tree.Invalidate();
                    }
                }
            };
            #endregion
            #region btnCancel.ButtonClick
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
            #endregion
            #region btnOK.ButtonClick 
            btnOK.ButtonClick += (o, s) =>
            {
                string msg = null;
                if (!string.IsNullOrWhiteSpace(inAddr.Value))
                {
                    if (Devinno.Tools.NetworkTool.ValidDomain(inAddr.Value)) DialogResult = DialogResult.OK;
                    else msg = "유효한 주소가 아닙니다.";
                }
                else msg = "주소를 입력하거나 조회 항목을 선택하세요.";

                if (msg != null)
                {
                    Block = true;
                    Program.MessageBox.ShowMessageBoxOk("", msg);
                    Block = false;
                }
            };
            #endregion
            #region btnPlus.ButtonClick
            btnPM.ButtonClick += (o, s) =>
            {
                if(s.Button.Name == "Add")
                {
                    #region Add
                    var ls = new Dictionary<string, InputBoxInfo>();
                    ls.Add("Name", new InputBoxInfo() { Title = "연결명" });
                    ls.Add("Address", new InputBoxInfo() { Title = "주소" });

                    Block = true;
                    var ret = Program.InputBox.ShowInputBox<ConnItem>("연결", null, ls);
                    Block = false;
                    if (ret != null)
                    {
                        if (NetworkTool.ValidIPv4(ret.Address))
                        {
                            var lstConn = GetConnectionItems();
                            lstConn.Add(ret);
                            Serialize.JsonSerializeToFile(Path_ConnList, lstConn);

                            tree.Nodes.Clear();
                            foreach (var v in lstConn)
                                tree.Nodes.Add(new DvTreeViewLabelNode(v.Name + " - " + v.Address) { Tag = v });

                            //tree.Nodes.Add(new Devinno.Forms.Controls.TreeViewNode(ret.Name + " - " + ret.Address) { Tag = ret });
                            //tree.Invalidate();
                        }
                        else
                        {
                            Block = true;
                            Program.MessageBox.ShowMessageBoxOk("", "잘못된 주소입니다.");
                            Block = false;
                        }
                    }
                    #endregion
                }
                else if(s.Button.Name == "Del")
                {
                    #region Del
                    if (tree.SelectedNodes.Count > 0)
                    {
                        foreach (var v in tree.SelectedNodes) tree.Nodes.Remove(v);
                        tree.Invalidate();

                        var ls = tree.Nodes.Where(x => x.Tag is ConnItem).Select(x => x.Tag as ConnItem).Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name != "Unknown").ToList();
                        Serialize.JsonSerializeToFile(Path_ConnList, ls);
                    }
                    #endregion
                }
            };
            #endregion

            #region Form Props
            StartPosition = FormStartPosition.CenterParent;
            this.Icon = Tools.IconTool.GetIcon(new Devinno.Forms.Icons.DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

            #region Icon
            Icon = IconTool.GetIcon(new DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion
        }
        #endregion

        #region Method
        #region GetConnectionItems
        List<ConnItem> GetConnectionItems()
        {
            var lstConn = new List<ConnItem>();
            lstConn.Clear();
            if (File.Exists(Path_ConnList))
            {
                lstConn = Serialize.JsonDeserializeFromFile<List<ConnItem>>(Path_ConnList);
            }
            return lstConn;
        }
        #endregion
        #region ShowConnect
        public string ShowConnect()
        {
            #region Connection List
            var lstConn = GetConnectionItems();
            tree.Nodes.Clear();
            foreach (var v in lstConn)
                tree.Nodes.Add(new DvTreeViewLabelNode(v.Name + " - " + v.Address) { Tag = v });
            tree.Invalidate();
            #endregion

            string ret = null;
            inAddr.Value = "";
            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = inAddr.Value;
            }
            return ret;
        }
        #endregion
        #endregion
    }

    #region class : Connitem
    public class ConnItem
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    #endregion
}
