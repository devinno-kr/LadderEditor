using AutocompleteMenuNS;
using Devinno.Forms;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;
using Devinno.PLC.Ladder;
using LadderEditor.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thread = System.Threading.Thread;
using ThreadStart = System.Threading.ThreadStart;

namespace LadderEditor.Forms
{
    public partial class LadderEditForm : DvForm
    {
        #region Const
        #endregion

        #region Properties
        LadderItem Item { get; set; }
        #endregion

        #region Member Variable
        Dictionary<string, string> DicK, DicE;
        bool bOpen = false;
        bool bLoop = false;
        AutocompleteMenu autocompleteMenu;

        int CH;
        #endregion

        #region Constructor
        public LadderEditForm()
        {
            InitializeComponent();

            #region TabStop
            btnOK.TabStop = false;
            btnCancel.TabStop = false;
            pnl.TabStop = false;
            txt.TabStop = false;
            txt.TabStop = true;
            txt.AcceptsTab = true;
            #endregion

            #region Set
            autocompleteMenu = new AutocompleteMenu();

            autocompleteMenu.ImageList = new System.Windows.Forms.ImageList();
            autocompleteMenu.ImageList.ImageSize = new System.Drawing.Size(16, 16);
            autocompleteMenu.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Class__16x);                     // 0    : Classes
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.ColorPalette__16x);              // 1    : Colors
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Document__16x);                  // 2    : Global Identifiers
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.EnumItem__16x);                  // 3    : References
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Enumerator__16x);                // 4    : Values and Enumerations and Define
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Field__16x);                     // 5    : Variables and Fields
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.IntelliSenseKeyword__16x);       // 6    : Keywords
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Interface__16x);                 // 7    : Interfaces
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Method__16x);                    // 8    : Methods, Functions and Constructors
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Misc__16x);                      // 9    : Miscellaneous
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Namespace__16x);                 // 10   : Modules
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Property__16x);                  // 11   : Properties and Attributes
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Ruler__16x);                     // 12   : Unit
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Snippet__16x);                   // 13   : Snippet Prefixes
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.String__16x);                    // 14   : Words
            autocompleteMenu.ImageList.Images.Add(Properties.Resources.Struct__16x);                    // 15   : Struct, Type

            autocompleteMenu.AllowsTabKey = true;
            autocompleteMenu.AppearInterval = 1;
            autocompleteMenu.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            autocompleteMenu.Items = new string[0];
            autocompleteMenu.TargetControlWrapper = null;
            autocompleteMenu.ToolTipDuration = 100;
            autocompleteMenu.SearchPattern = "[\\w\\.@]";
            autocompleteMenu.SetAutocompleteMenu(txt, autocompleteMenu);

            autocompleteMenu.Colors.BackColor = Color.FromArgb(40, 40, 40);
            autocompleteMenu.Colors.ForeColor = Color.White;
            autocompleteMenu.Colors.SelectedBackColor = Color.DarkRed;
            autocompleteMenu.Colors.SelectedBackColor2 = Color.DarkRed;
            autocompleteMenu.Colors.HighlightingColor = Color.DarkRed;
            autocompleteMenu.Colors.SelectedForeColor = Color.White;
            #endregion

            #region Dic
            DicK = LadderFunc.Funcs.ToDictionary(x => x.Name, y => y.DescriptionKO);
            DicE = LadderFunc.Funcs.ToDictionary(x => x.Name, y => y.DescriptionEN);
            #endregion

            #region Form Props
            StartPosition = FormStartPosition.CenterParent;
            this.Icon = Tools.IconTool.GetIcon(new Devinno.Forms.Icons.DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

            #region Icon
            Icon = IconTool.GetIcon(new DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

            #region Event
            #region txt.KeyUp
            txt.KeyUp += (o, s) =>
            {
                SetLabel();
                MakeAutoComplete();

                #region Enter / ESC
                if (!bOpen)
                {
                    if (txt.Text.StartsWith("{"))
                    {
                        if (s.KeyCode == Keys.Escape) { DialogResult = DialogResult.Cancel; }
                    }
                    else
                    {
                        if (s.KeyCode == Keys.Escape) { DialogResult = DialogResult.Cancel; }
                        else if (s.KeyCode == Keys.Enter)
                        {
                            if (!bOpen) { DialogResult = DialogResult.OK; }
                        }
                    }
                }
                #endregion
            };
            #endregion
            #region btnOK.ButtonClick
            btnOK.ButtonClick += (o, s) => { DialogResult = DialogResult.OK; };
            #endregion
            #region btnCancel.ButtonClick
            btnCancel.ButtonClick += (o, s) => { DialogResult = DialogResult.Cancel; };
            #endregion
            #region autocompleteMenu.Opening 
            autocompleteMenu.Opening += (o, s) => bOpen = true;
            autocompleteMenu.Closing += (o, s) => { ThreadPool.QueueUserWorkItem((p) => { Thread.Sleep(100); bOpen = false; }); };
            //autocompleteMenu.Selected += (o, s) => { ThreadPool.QueueUserWorkItem((p) => { Thread.Sleep(100); bOpen = false; }); };
            #endregion
            #endregion

            CH = pnlContent.Height;
        }
        #endregion

        #region Method
        #region LangSet
        void LangSet()
        {
            if (Program.DataMgr.Language == Managers.Lang.KO)
            {
                Title = "편집";
                dvLabel1.Text = "설명";
                btnOK.Text = "확인";
                btnCancel.Text = "취소";
            }
            else if (Program.DataMgr.Language == Managers.Lang.EN)
            {
                Title = "Edit";
                dvLabel1.Text = "Description";
                btnOK.Text = "Ok";
                btnCancel.Text = "Cancel";
            }
        }
        #endregion
        #region ShowLadderCode
        public string ShowLadderCode(LadderItem ld)
        {
            string ret = null;

            this.Item = ld;

            #region WindowSize
            if (ld != null && ld.ItemType == LadderItemType.OUT_FUNC)
            {
                this.Size = new Size(500, 400);
                this.pnlContent.Visible = true;
            }
            else
            {
                this.Size = new Size(300, 400 - CH);
                this.pnlContent.Visible = false;
            }
            #endregion
            #region Select
            txt.Width = txt.Width - (txt.Padding.Left + txt.Padding.Right);
            if (ld != null && ld.Code.StartsWith("{"))
            {
                txt.Select();
                new Thread(new ThreadStart(() =>
                {
                    while (!this.IsHandleCreated) Thread.Sleep(10);
                    this.Invoke(new Action(() =>
                    {
                        txt.SelectionStart = 0;
                        txt.SelectionLength = 0;
                    }));
                }))
                { IsBackground = true }.Start();
            }
            else
            {
                txt.Select();
                new Thread(new ThreadStart(() =>
                {
                    while (!this.IsHandleCreated) Thread.Sleep(10);
                    this.Invoke(new Action(() =>
                    {
                        txt.SelectAll();
                    }));
                }))
                { IsBackground = true }.Start();
            }
            #endregion
            #region UI
            if (ld != null) txt.Text = ld.Code;
            else txt.Text = "";
            SetLabel();
            MakeAutoComplete();
            #endregion

            LangSet();

            if (this.ShowDialog() == DialogResult.OK)
            {
                if (txt.Text.Length >= 2 && txt.Text.StartsWith("''"))
                {
                    #region Remark
                    var s = txt.Text;
                    var wds = LadderTool.GetWords(txt.Text);
                    if (Program.MainForm.CurrentDocument != null)
                    {
                        foreach (var v in wds)
                            if (Program.MainForm.CurrentDocument.ValidSymbol(v))
                                s = s.Replace(v, v.ToUpper());
                    }
                    ret = s;
                    #endregion
                }
                else if (txt.Text.StartsWith("{"))
                {
                    #region Expand Code
                    var s = txt.Text;
                    //var wds = LadderTool.GetWordsForCode(txt.Text);
                    var wds = LadderTool.GetWords(txt.Text);
                    if (Program.MainForm.CurrentDocument != null)
                    {
                        foreach (var v in wds)
                        {
                            if (Program.MainForm.CurrentDocument.ValidSymbol(v))
                                s = s.Replace(v, v.ToUpper());
                        }
                    }
                    ret = s;
                    #endregion
                }
                else
                {
                    #region Code
                    var s = txt.Text;
                    var wds = LadderTool.GetWords(s);
                    var fns = LadderFunc.Funcs.Select(x => x.Name).ToList();

                    if (Program.MainForm.CurrentDocument != null)
                    {
                        var first = wds.FirstOrDefault();
                        if (first != null && fns.Contains(first.ToUpper()))
                        {
                            s = s.Replace(first, first.ToUpper());
                        }

                        foreach (var v in wds)
                            if (Program.MainForm.CurrentDocument.ValidSymbol(v))
                                s = s.Replace(v, v.ToUpper());

                    }

                    ret = s;
                    #endregion
                }
            }

            return ret;
        }
        #endregion
        #region SetLabel
        void SetLabel()
        {
            if (Item != null && Item.ItemType == LadderItemType.OUT_FUNC)
            {
                autocompleteMenu.MinFragmentLength = 2;
                var bCode = txt.Text.StartsWith("{");
                if (bCode)
                {
                    SuspendLayout();
                    pnl.Dock = DockStyle.Fill;
                    pnlContent.Visible = false;
                    txt.Multiline = true;
                    txt.AcceptsTab = true;
                    ResumeLayout();
                    PerformLayout();
                }
                else
                {
                    SuspendLayout();
                    pnl.Dock = DockStyle.Top;
                    pnlContent.Visible = true;
                    txt.Multiline = false;
                    txt.AcceptsTab = false;
                    ResumeLayout();
                    PerformLayout();
                }
                if (!bCode)
                {
                    var fn = txt.Text.Split('(').FirstOrDefault()?.ToUpper()?.Trim();
                    var Dic = Program.DataMgr.Language == Managers.Lang.KO ? DicK : DicE;

                    if (fn != null && Dic != null && Dic.ContainsKey(fn))
                        lblDesc.Text = Dic[fn];
                    else
                    {
                        var doc = Program.MainForm.CurrentDocument;
                        var libMgr = Program.LibMgr;

                        var m = "";
                        try
                        {
                            var ms = txt.Text.Split('.', '(', ')', ',', '+', '-', '*', '/');
                            if (ms.Length >= 2)
                            {
                                var inst = ms[0];
                                var mthd = ms[1];

                                var b1 = txt.Text.Length > txt.Text.IndexOf(inst) + inst.Length ? txt.Text[txt.Text.IndexOf(inst) + inst.Length] == '.' : false;
                                var b2 = txt.Text.Length > txt.Text.IndexOf(mthd) + mthd.Length ? txt.Text[txt.Text.IndexOf(mthd) + mthd.Length] == '(' : false;

                                var v = doc.Libraries.Where(x => x.InstanceName == inst).FirstOrDefault();
                                if (v != null && libMgr.Classes.ContainsKey(v.Name))
                                {
                                    var v2 = libMgr.Classes[v.Name].Where(x => x.Text == mthd).FirstOrDefault();
                                
                                    if(v2 != null && !string.IsNullOrWhiteSpace(v2.Desc))
                                    {
                                        m = v2.Desc;
                                    }
                                }
                            }
                        }
                        catch { }
                         
                        lblDesc.Text = m;
                    }
                }
            }
            else
            {
                SuspendLayout();
                autocompleteMenu.MinFragmentLength = 1;
                pnl.Dock = DockStyle.Top;
                pnlContent.Visible = true;
                txt.Multiline = false;
                txt.AcceptsTab = false;

                lblDesc.Text = "";
                ResumeLayout();
                PerformLayout();
            }

        }
        #endregion
        #region MakeAutoComplete
        void MakeAutoComplete()
        {
            var doc = Program.MainForm.CurrentDocument;
            var libMgr = Program.LibMgr;
            if (Item != null && doc != null)
            {
                if (Item.ItemType == LadderItemType.OUT_FUNC)
                {
                    var items = new List<AutocompleteItem>();
         
                    #region Funcs
                    items.AddRange(LadderFunc.Funcs.Select(x => new AutocompleteItem(x.Name) { ImageIndex = 8 }).ToArray());
                    #endregion
                    #region Library
                    var nm = txt.Text.Split('.').FirstOrDefault();
                    if (nm != null)
                    {
                        var v = doc.Libraries.Where(x => x.InstanceName == nm).FirstOrDefault();
                        if (v != null && libMgr.Classes.ContainsKey(v.Name))
                        {
                            foreach (var v2 in libMgr.Classes[v.Name])
                                items.Add(new MethodAutocompleteItem(v2.Text) { ImageIndex = v2.ImageIndex });
                        }
                    }
                    #endregion
                    #region Symbol
                    {
                        items.AddRange(doc.Symbols.Select(x => new AutocompleteItem(x.SymbolName) { ImageIndex = 5 }));
                    }
                    #endregion

                    autocompleteMenu.SetAutocompleteItems(items);
                }
                else
                {
                    var items = new List<AutocompleteItem>();

                    #region SpecialRelay
                    items.AddRange(LadderSpecialRelay.Relays.Select(x => new AutocompleteItem(x.Syntax)));
                    #endregion
                    #region Symbol
                    {
                        items.AddRange(doc.Symbols.Select(x => new AutocompleteItem(x.SymbolName) { ImageIndex = 5 }));
                    }
                    #endregion


                    autocompleteMenu.SetAutocompleteItems(items);
                }
            }
        }
        #endregion
        #endregion
    }


}
