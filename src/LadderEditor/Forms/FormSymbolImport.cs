using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;
using Devinno.PLC.Ladder;
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
    public partial class FormSymbolImport : DvForm
    {
        #region class : Result
        public class Result
        {
            public List<SymbolInfo> List { get; set; } = new List<SymbolInfo>();
        }
        #endregion

        #region Member Variable
        FormSymbol.Result Data;
        #endregion

        #region Constructor
        public FormSymbolImport()
        {
            InitializeComponent();

            #region btn[OK/Cancel].ButtonClick
            btnOK.ButtonClick += (o, s) => { if (ValidCheck()) DialogResult = DialogResult.OK; };
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
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
        #region ValidCheck
        bool ValidCheck()
        {
            bool ret = true;

            lblMessage.Text = "";

            var Data = new FormSymbol.Result()
            {
                P_Count = this.Data.P_Count,
                M_Count = this.Data.M_Count,
                T_Count = this.Data.T_Count,
                C_Count = this.Data.C_Count,
                D_Count = this.Data.D_Count,
                Symbols = this.Data.Symbols.Select(x => new Devinno.PLC.Ladder.SymbolInfo() { SymbolName = x.SymbolName, Address = x.Address }).ToList()
            };

            var vtxt = txt.Text.Replace("\r\n", "\n");
            using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(vtxt))))
            {
                int len = vtxt.Length;
                int offset = 0;
                while (!sr.EndOfStream)
                {
                    var v = sr.ReadLine();
                    if (!string.IsNullOrWhiteSpace(v))
                    {
                        var r = SymbolTool.InputLineCheck(Data, v);
                        if (r.Success)
                            Data.Symbols.Add(new SymbolInfo() { SymbolName = r.SymbolName, Address = r.Address.ToUpper() });
                        else
                        {
                            ret &= r.Success;
                            txt.OriginalTextBox.Select();
                            txt.OriginalTextBox.SelectionStart = offset;
                            txt.OriginalTextBox.SelectionLength = v.Length;
                            lblMessage.Text = r.Message;
                            break;
                        }
                    }
                    offset += v.Length + (!sr.EndOfStream ? 1 : 0);
                }
            }

            return ret;
        }
        #endregion
        #region ShowSymbolImport
        public Result ShowSymbolImport(FormSymbol.Result Data)
        {
            this.Data = Data;
            txt.Text = "";
            Result ret = null;
            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = new Result();
                var vtxt = txt.Text;
                using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(vtxt))))
                {
                    while (!sr.EndOfStream)
                    {
                        var v = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(v))
                        {
                            var r = SymbolTool.InputLineCheck(Data, v);
                            if (r.Success)
                            {
                                var sym = new SymbolInfo() { SymbolName = r.SymbolName, Address = r.Address.ToUpper() };
                                ret.List.Add(sym);
                            }
                        }
                    }
                }
            }
            return ret;
        }
        #endregion
        #endregion
    }
}
