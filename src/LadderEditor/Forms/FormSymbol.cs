using Devinno.Extensions;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;
using Devinno.Forms.Themes;
using Devinno.PLC.Ladder;
using Devinno.Tools;
using LadderEditor.Datas;
using LadderEditor.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LadderEditor.Forms
{
    public partial class FormSymbol : DvForm
    {
        #region [Class] Result
        public class Result
        {
            public int P_Count { get; set; } = LadderBase.MAX_P_COUNT;
            public int M_Count { get; set; } = LadderBase.MAX_M_COUNT;
            public int T_Count { get; set; } = LadderBase.MAX_T_COUNT;
            public int C_Count { get; set; } = LadderBase.MAX_C_COUNT;
            public int D_Count { get; set; } = LadderBase.MAX_D_COUNT;

            public List<SymbolInfo> Symbols { get; set; } = new List<SymbolInfo>();
        }
        #endregion

        #region Member Variable
        EditorLadderDocument doc;
        Result Data = new Result();
        DvInputBox frmNumBox;
        FormSymbolImport frmSymbolImport;
        #endregion

        #region Constructor
        public FormSymbol()
        {
            InitializeComponent();

            #region DataGrid
            dg.Columns.Add(new DvDataGridColumn(dg) { Name = "Address", HeaderText = "주소", SizeMode = DvSizeMode.Percent, Width = 50, UseSort = true, UseFilter = true });
            dg.Columns.Add(new DvDataGridColumn(dg) { Name = "SymbolName", HeaderText = "명칭", SizeMode = DvSizeMode.Percent, Width = 50, UseSort = true, UseFilter = true });
            dg.ColumnColor = Color.FromArgb(30, 30, 30);
            dg.SelectionMode = DvDataGridSelectionMode.Selector;
            #endregion
            #region Forms
            frmNumBox = new DvInputBox() { StartPosition = FormStartPosition.CenterParent };
            frmSymbolImport = new FormSymbolImport() { StartPosition = FormStartPosition.CenterParent };
            #endregion
            #region Buttons
            btnPM.Buttons.Add(new ButtonInfo("Plus") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            btnPM.Buttons.Add(new ButtonInfo("Minus") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            #endregion

            #region lbl[P/M/T/C/D/F].ButtonClick
            lblP.ButtonClicked += (o, s) => { Block = true; var r = frmNumBox.ShowInt("P 영역 크기", Data.P_Count, 128, LadderBase.MAX_P_COUNT); if (r.HasValue) Data.P_Count = Convert.ToInt32(r.Value); Block = false; Set(); };
            lblM.ButtonClicked += (o, s) => { Block = true; var r = frmNumBox.ShowInt("M 영역 크기", Data.M_Count, 128, LadderBase.MAX_M_COUNT); if (r.HasValue) Data.M_Count = Convert.ToInt32(r.Value); Block = false; Set(); };
            lblT.ButtonClicked += (o, s) => { Block = true; var r = frmNumBox.ShowInt("T 영역 크기", Data.T_Count, 128, LadderBase.MAX_T_COUNT); if (r.HasValue) Data.T_Count = Convert.ToInt32(r.Value); Block = false; Set(); };
            lblC.ButtonClicked += (o, s) => { Block = true; var r = frmNumBox.ShowInt("C 영역 크기", Data.C_Count, 128, LadderBase.MAX_C_COUNT); if (r.HasValue) Data.C_Count = Convert.ToInt32(r.Value); Block = false; Set(); };
            lblD.ButtonClicked += (o, s) => { Block = true; var r = frmNumBox.ShowInt("D 영역 크기", Data.D_Count, 64, LadderBase.MAX_D_COUNT); if (r.HasValue) Data.D_Count = Convert.ToInt32(r.Value); Block = false; Set(); };
            #endregion
            #region btn[OK/Cancel].ButtonClick
            btnOK.ButtonClick += (o, s) => { if (ValidCheck()) DialogResult = DialogResult.OK; };
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
            #endregion
            #region btnPM.ButtonClick
            btnPM.ButtonClick += (o, s) =>
            {
                if (s.Button.Name == "Plus") Add();
                if (s.Button.Name == "Minus") Del();
            };
            #endregion
            #region btnImport.ButtonClick
            btnImport.ButtonClick += (o, s) =>
            {
                Block = true;
                var ret = frmSymbolImport.ShowSymbolImport(Data);
                if (ret != null)
                {
                    Data.Symbols.Clear();
                    Data.Symbols.AddRange(ret.List);
                    Set();
                }
                Block = false;
            };
            #endregion
            #region  txt.OriginalTextBox.KeyPress
            txt.OriginalTextBox.KeyPress += (o, s) =>
            {
                if (s.KeyChar == '\r')
                {
                    Add();
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
        #region ValidCheck
        bool ValidCheck()
        {
            bool ret = true;

            return ret;
        }
        #endregion
        #region Set
        void Set()
        {
            if (Data != null)
            {
                lblP.Value = Data.P_Count;
                lblM.Value = Data.M_Count;
                lblT.Value = Data.T_Count;
                lblC.Value = Data.C_Count;
                lblD.Value = Data.D_Count;

                dg.SetDataSource<SymbolInfo>(Data.Symbols);
                dg.Invalidate();
                ValidCheck();
            }
        }
        #endregion
        #region Add
        void Add()
        {
            var r = SymbolTool.InputLineCheck(Data, txt.Value);
            if (r.Success)
            {
                Data.Symbols.Add(new SymbolInfo() { SymbolName = r.SymbolName, Address = r.Address.ToUpper() });

                var old = dg.VScrollPosition;
                Set();
                dg.VScrollPosition = old;

                txt.Value = "";
                txt.OriginalTextBox.SelectAll();
            }
            else
            {
                Block = true;
                Program.MessageBox.ShowMessageBoxOk("입력", r.Message);
                Block = false;
            }
        }
        #endregion
        #region Del
        void Del()
        {
            var ls = dg.Rows.Where(x => x.Selected).ToList();

            if (ls.Count > 0)
            {
                Block = true;

                if (Program.MessageBox.ShowMessageBoxYesNo("삭제", "선택한 항목을 삭제하시겠습니까?") == DialogResult.Yes)
                {
                    var old = dg.VScrollPosition;

                    foreach (var row in ls)
                    {
                        var v = row.Source as SymbolInfo;
                        if (v != null)
                            Data.Symbols.Remove(v);
                    }
                    Set();

                    dg.VScrollPosition = old;
                }
                Block = false;
            }
        }
        #endregion
        #region GetCount
        int? GetCount(string code)
        {
            int? ret = null;
            switch (code.ToUpper())
            {
                case "P": ret = Data.P_Count; break;
                case "M": ret = Data.M_Count; break;
                case "T": ret = Data.T_Count; break;
                case "C": ret = Data.C_Count; break;
                case "D": ret = Data.D_Count; break;
            }
            return ret;
        }
        #endregion

        #region ShowSymbol
        public Result ShowSymbol(EditorLadderDocument doc)
        {
            Result ret = null;
            
            #region Set
            this.doc = doc;
            Data = new Result();
            if (doc != null)
            {
                Data.P_Count = doc.P_Count;
                Data.M_Count = doc.M_Count;
                Data.T_Count = doc.T_Count;
                Data.C_Count = doc.C_Count;
                Data.D_Count = doc.D_Count;
                Data.Symbols = doc.Symbols.Select(x => new SymbolInfo() { SymbolName = x.SymbolName, Address = x.Address }).ToList();
            }
            Set();
            #endregion
            #region ShowDialog
            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = Data;
            }
            #endregion

            return ret;
        }
        #endregion
        #endregion
    }
}
