using Devinno.Data;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;
using Devinno.PLC.Ladder;
using Devinno.Tools;
using LadderEditor.Datas;
using LadderEditor.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LM = LadderEditor.Tools.LangTool;

namespace LadderEditor.Forms
{
    public partial class FormCommunication : DvForm
    {
        #region Member Variable
        FormCommunicationInput frmInput = new FormCommunicationInput() { StartPosition = FormStartPosition.CenterParent };
        List<LadderCommItem> Items = new List<LadderCommItem>();
        #endregion

        #region Constructor
        public FormCommunication()
        {
            InitializeComponent();

            #region DataGrid
            dg.Columns.Add(new DvDataGridColumn(dg) { Name = "Name", HeaderText = LM.CommunicationType, SizeMode = DvSizeMode.Percent, Width = 30, CellType = typeof(DvDataGridLabelCell) });
            dg.Columns.Add(new DvDataGridColumn(dg) { Name = "Summary", HeaderText = LM.Information, SizeMode = DvSizeMode.Percent, Width = 70, CellType = typeof(DvDataGridLabelCell) });
            dg.Columns.Add(new DvDataGridButtonColumn(dg) { Name = "Tag", HeaderText = "", SizeMode = DvSizeMode.Pixel, Width = 50, Text = "..." });

            dg.ColumnColor = Color.FromArgb(30, 30, 30);
            dg.SelectionMode = DvDataGridSelectionMode.Selector;
            #endregion
            
            #region Buttons 
            btnPM.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            btnPM.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            #endregion

            #region Event
            #region dg.CellButtonClick
            dg.CellButtonClick += (o, s) => {

                var v = s.Cell.Row.Source as LadderCommItem;
                if (v != null)
                {
                    Block = true;
                    ILadderComm ret = frmInput.ShowCommInputModify(v.Comm);
                    Block = false;

                    if (ret != null)
                    {
                        var idx = Items.IndexOf(v);
                        Items.Insert(idx, new LadderCommItem(ret));
                        Items.Remove(v);
                        dg.SetDataSource<LadderCommItem>(Items);
                    }
                }

            };
            #endregion
            #region btn[OK/Cancel].ButtonClick
            btnOK.ButtonClick += (o, s) => DialogResult = DialogResult.OK;
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
            #endregion
            #region btnPlus.ButtonClick
            btnPM.ButtonClick += (o, s) =>
            {
                if(s.Button.Name == "Add")
                {
                    Block = true;
                    ILadderComm ret = frmInput.ShowCommInputAdd();
                    Block = false;

                    if (ret != null)
                    {
                        Items.Add(new LadderCommItem(ret));
                        dg.SetDataSource<LadderCommItem>(Items);
                    }
                }
                else if(s.Button.Name == "Del")
                {
                    var sels = dg.Rows.Where(x => x.Selected).Select(x => x.Source as LadderCommItem).ToList();
                    if (sels.Count > 0)
                    {
                        foreach (var v in sels)
                            if (Items.Contains(v))
                                Items.Remove(v);

                        dg.SetDataSource<LadderCommItem>(Items);
                    }
                }
            };
            #endregion
            #endregion

            #region Icon
            Icon = IconTool.GetIcon(new DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

            StartPosition = FormStartPosition.CenterParent;
        }
        #endregion

        #region Method
        #region LangSet
        void LangSet()
        {

            Title = LM.Communication;
            lblTitleAreas.Text = LM.CommunicationList;
            btnOK.Text = LM.Ok;
            btnCancel.Text = LM.Cancel;
            dg.Columns[0].HeaderText = LM.CommunicationType;
            dg.Columns[1].HeaderText = LM.Information;
             
        }
        #endregion

        #region ShowCommunication
        public List<ILadderComm> ShowCommunication(EditorLadderDocument doc)
        {
            #region Set
            Items.Clear();
            if (doc != null && !string.IsNullOrWhiteSpace(doc.Communications))
            {
                try
                {
                    var str = CryptoTool.DecodeBase64String<string>(doc.Communications);
                    var ls = Serialize.JsonDeserializeWithType<List<ILadderComm>>(str);
                    Items.AddRange(ls.Select(x => new LadderCommItem(x)));
                }
                catch { }
            }
            dg.SetDataSource<LadderCommItem>(Items);
            #endregion

            LangSet();

            List<ILadderComm> ret = null;
            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = Items.Select(x=>x.Comm).ToList();
            }
            return ret;
        }
        #endregion
        #endregion
    }

    #region class : LadderCommItem
    public class LadderCommItem
    {
        public string Name { get; private set; }
        public string Summary { get; private set; }
        public ILadderComm Comm { get; private set; }
    
        public LadderCommItem(ILadderComm Comm)
        {
            this.Comm = Comm;
            this.Name = Comm.Name;
            this.Summary = LM.Summary(Comm.Summary);
        }
    }
    #endregion
}
