using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;
using Devinno.PLC.Ladder;
using LadderEditor.Controls;
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
using LM = LadderEditor.Managers.LangTool;

namespace LadderEditor.Forms
{
    public partial class FormSearch : DvForm
    {
        #region Member Variable
        LadderEditorControl editor;

        int SearchIndex = 0;
        string SearchText = "";
        List<FindItem> ls = new List<FindItem>();
        #endregion

        #region Constructor
        public FormSearch()
        {
            InitializeComponent();

            inSearch.OriginalTextBox.KeyUp += (o, s) => { if (s.KeyCode == Keys.Enter) Search(); };
            btnSearch.ButtonClick += (o, s) => Search();
            btnClose.ButtonClick += (o, s) => this.Close();

            #region Icon
            StartPosition = FormStartPosition.CenterParent;
            Icon = IconTool.GetIcon(new DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion
        }
        #endregion

        #region Override
        #region OnShow
        protected override void OnShown(EventArgs e)
        {
            inSearch.OriginalTextBox.Focus();
            inSearch.OriginalTextBox.SelectAll();
            base.OnShown(e);
        }
        #endregion
        #endregion

        #region Method
        #region Search
        private void Search()
        {
            if (!string.IsNullOrWhiteSpace(inSearch.Value))
            {
                if (SearchText != inSearch.Value)
                {
                    SearchText = inSearch.Value;
                    SearchIndex = 0;

                    var items = editor.Ladders.Select(x => new FindItem { Item = x }).ToList();
                    foreach (var v in items)
                    {
                        var vi = Program.MainForm.CurrentDocument.Symbols.Where(x => x.Address == v.Item.Code).FirstOrDefault();
                        if (vi != null) v.Alias = vi.SymbolName;
                    }

                    ls = items.Where(x => (x.Item.Code != null && x.Item.Code.IndexOf(SearchText) != -1) || (x.Alias != null && x.Alias.IndexOf(SearchText) != -1)).ToList();
                }

                if (ls.Count > 0 && SearchIndex >= 0 && SearchIndex < ls.Count)
                {
                    var cc = ls[SearchIndex].Item.Col;
                    var cr = ls[SearchIndex].Item.Row;

                    if (editor.DicRows.ContainsKey(cr))
                    {
                        var r = editor.DicRows[cr];
                        while (r != null)
                        {
                            r.Expand = true;
                            r = editor.DicRows[r.Row].Parent;
                        }
                        editor.MakeRows();
                        var cy = editor.Rows.IndexOf(editor.DicRows[cr]);
                        editor.CurY = cy;
                        editor.CurX = cc;
                    }


                    SearchIndex++;
                    if (SearchIndex >= ls.Count) SearchIndex = 0;
                }
            }
        }
        #endregion
        #region LangSet
        void LangSet()
        {
            Title = LM.Search;
            inSearch.Title = LM.SearchWord;
            btnSearch.Text = LM.Search;
            btnClose.Text = LM.Close;
        }
        #endregion
        #region ShowSearch
        public void ShowSearch(LadderEditorControl editor)
        {
            this.editor = editor;
            this.SearchIndex = 0;
            this.SearchText = "";

            LangSet();

            this.Show();
        }
        #endregion
        #endregion
    }

    #region class : FindItem
    public class FindItem
    {
        public LadderItem Item { get; set; }
        public string Alias { get; set; }
    }
    #endregion
}
