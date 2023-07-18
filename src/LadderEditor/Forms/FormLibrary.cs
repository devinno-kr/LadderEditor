using Devinno.Forms;
using Devinno.Forms.Controls;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LM = LadderEditor.Managers.LangTool;

namespace LadderEditor.Forms
{
    public partial class FormLibrary : DvForm
    {
        #region Member Variable
        List<LadderLibrary> Libs = new List<LadderLibrary>();
        #endregion

        #region Constructor
        public FormLibrary()
        {
            InitializeComponent();

            #region Icon
            StartPosition = FormStartPosition.CenterParent;
            Icon = IconTool.GetIcon(new DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

            #region Set
            #region dragDLL
            dragDLL.AllowDrop = true;
            #endregion
            #region dgLibrary
            dgLibrary.SelectionMode = DvDataGridSelectionMode.Selector;
            dgLibrary.Columns.Add(new DvDataGridColumn(dgLibrary) { Name = "Name", HeaderText = LM.Library, Width = 50M, SizeMode = DvSizeMode.Percent });
            dgLibrary.Columns.Add(new DvDataGridColumn(dgLibrary) { Name = "DllPath", HeaderText = "DLL", Width = 50M, SizeMode = DvSizeMode.Percent });
            #endregion
            #region dgReference
            dgReference.SelectionMode = DvDataGridSelectionMode.Selector;
            dgReference.Columns.Add(new DvDataGridColumn(dgReference) { Name = "Name", HeaderText = LM.Library, Width = 40M, SizeMode = DvSizeMode.Percent });
            dgReference.Columns.Add(new DvDataGridColumn(dgReference) { Name = "DllPath", HeaderText = "DLL", Width = 30M, SizeMode = DvSizeMode.Percent });
            dgReference.Columns.Add(new DvDataGridEditTextColumn(dgReference) { Name = "InstanceName", HeaderText = LM.VariableName, Width = 30M, SizeMode = DvSizeMode.Percent });
            #endregion
            #endregion

            #region Event
            #region btn[OK/Cancel].ButtonClick
            btnOK.ButtonClick += (o, s) => DialogResult = DialogResult.OK;
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
            #endregion
            #region dragDLL.DragEnter
            dragDLL.DragEnter += (o, s) =>
            {
                if (s.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var files = (string[])s.Data.GetData(DataFormats.FileDrop);
                    var dlls = files.Where(x => Path.GetExtension(x).ToLower() == ".dll").ToList();

                    if (files.Length == 1 && dlls.Count == 1)
                    {
                        var vref = DllTool.Load(dlls[0], (asm, tp, vref, vlib) => { });
                        if (vref != null && vref.Libraries.Count > 0) s.Effect = DragDropEffects.Copy;
                    }
                }
            };
            #endregion
            #region dragDLL.DragDrop
            dragDLL.DragDrop += (o, s) =>
            {
                var files = (string[])s.Data.GetData(DataFormats.FileDrop);
                var dlls = files.Where(x => Path.GetExtension(x).ToLower() == ".dll").ToList();

                if (files.Length == 1 && dlls.Count == 1)
                {
                    Program.LibMgr.UploadLibrary(dlls[0]);
                    RefreshLibrary();
                }
            };
            #endregion
            #region btnReg.ButtonClick 
            btnReg.ButtonClick += (o, s) =>
            {
                var sels = dgLibrary.Rows.Where(x => x.Selected).ToList();
                if(sels.Count > 0)
                {
                    Libs.AddRange(sels.Select(x => (LadderLibrary)x.Source));
                    RefreshLibrary();
                }
            };
            #endregion
            #region btnUnreg.ButtonClick
            btnUnreg.ButtonClick += (o, s) =>
            {
                var sels = dgReference.Rows.Where(x => x.Selected).ToList();
                if (sels.Count > 0)
                {
                    foreach (var v in sels) Libs.Remove((LadderLibrary)v.Source);
                    RefreshLibrary();
                }
            };
            #endregion
            #endregion
        }
        #endregion

        #region Method
        #region RefreshLibrary
        void RefreshLibrary()
        {
            var ls = new List<LadderLibrary>();
            foreach (var v in Program.LibMgr.References) ls.AddRange(v.Libraries);

            dgLibrary.SetDataSource<LadderLibrary>(ls);
            dgLibrary.Invalidate();

            dgReference.SetDataSource<LadderLibrary>(Libs);
            dgReference.Invalidate();
        }
        #endregion
        #region LangSet
        void LangSet()
        {
            Title = LM.Library;
            dvLabel1.Text = LM.LibraryList;
            dvLabel2.Text = LM.LibraryReference;
            dgLibrary.Columns[0].HeaderText = LM.Library;
            dgReference.Columns[0].HeaderText = LM.Library;
            dgReference.Columns[2].HeaderText = LM.VariableName;
            btnOK.Text = LM.Ok;
            btnCancel.Text = LM.Cancel;
        }
        #endregion
        #region ShowLibrary
        public List<LadderLibrary> ShowLibrary(List<LadderLibrary> libs)
        {
            List<LadderLibrary> ret = null;
            
            Libs.Clear();
            Libs.AddRange(libs);

            RefreshLibrary();

            LangSet();

            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = Libs;
            }

            return ret;
        }
        #endregion
        #endregion

    }
}
