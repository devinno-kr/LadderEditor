using Devinno.Data;
using Devinno.Extensions;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Extensions;
using Devinno.Forms.Icons;
using Devinno.Forms.Themes;
using Devinno.Forms.Tools;
using Devinno.PLC.Ladder;
using Devinno.Tools;
using LadderEditor.Controls;
using LadderEditor.Datas;
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
using LM = LadderEditor.Tools.LangTool;

namespace LadderEditor.Forms
{
    public partial class FormMain : DvForm
    {
        #region Properties
        public EditorLadderDocument CurrentDocument { get; private set; } = null;
        #endregion

        #region Member Variable
        FormConnect frmConnect;
        FormDescription frmDescription;
        FormSymbol frmSymbol;
        FormCommunication frmComm;
        FormLibrary frmLibrary;
        FormSetting frmSetting;
        FormMultiDownload frmMultiDown;

        Timer tmr;
        bool bSaveFileDown = false;
        Size szold;
        #endregion

        #region Constructor
        public FormMain()
        {
            InitializeComponent();

            #region Forms
            frmConnect = new FormConnect();
            frmDescription = new FormDescription();
            frmSymbol = new FormSymbol();
            frmComm = new FormCommunication();
            frmLibrary = new FormLibrary();
            frmSetting = new FormSetting();
            frmMultiDown = new FormMultiDownload();
            #endregion

            #region Grid
            gridMessage.SelectionMode = DvDataGridSelectionMode.Single;
            gridMessage.ColumnColor = Color.FromArgb(50, 50, 50);
            gridMessage.Columns.Add(new DvDataGridColumn(gridMessage) { Name = "Row", HeaderText = LM.Row, SizeMode = DvSizeMode.Pixel, Width = 70, CellType = typeof(DvDataGridLabelCell) });
            gridMessage.Columns.Add(new DvDataGridColumn(gridMessage) { Name = "Column", HeaderText = LM.Col, SizeMode = DvSizeMode.Pixel, Width = 70, CellType = typeof(DvDataGridLabelCell) });
            gridMessage.Columns.Add(new DvDataGridColumn(gridMessage) { Name = "Message", HeaderText = LM.Message, SizeMode = DvSizeMode.Percent, Width = 100, CellType = typeof(DvDataGridLabelCell) });
            #endregion

            #region Ladder Properties
            ladder.RowHeight = 36;
            ladder.ColumnCount = 14;
            #endregion

            #region Timer
            tmr = new Timer();
            tmr.Interval = 10;
            tmr.Tick += (o, s) => UISet();
            tmr.Enabled = true;
            #endregion

            #region Event
            #region btnSaveAsFile.ThemeDraw         : 아이콘 그리기
            btnSaveAsFile.MouseDown += (o, s) => bSaveFileDown = true;
            btnSaveAsFile.MouseUp += (o, s) => bSaveFileDown = false;
            btnSaveAsFile.ThemeDraw += (o, s) =>
            {
                using (var br = new SolidBrush(btnSaveAsFile.ButtonColor ?? Theme.ButtonColor))
                {
                    var n = bSaveFileDown ? 1 : 0;
                    int x = 20, y = 20, gp = 3;

                    br.Color = btnSaveAsFile.ButtonColor ?? Theme.ButtonColor;
                    s.Graphics.DrawIcon(new DvIcon("fa-asterisk") { IconSize = 7 }, br, new Rectangle(x - gp, y + n - gp, 10, 10), Devinno.Forms.DvContentAlignment.MiddleCenter);
                    s.Graphics.DrawIcon(new DvIcon("fa-asterisk") { IconSize = 7 }, br, new Rectangle(x - 0, y + n - gp, 10, 10), Devinno.Forms.DvContentAlignment.MiddleCenter);
                    s.Graphics.DrawIcon(new DvIcon("fa-asterisk") { IconSize = 7 }, br, new Rectangle(x - gp, y + n - 0, 10, 10), Devinno.Forms.DvContentAlignment.MiddleCenter);

                    br.Color = bSaveFileDown ? btnSaveAsFile.ForeColor.BrightnessTransmit(Theme.DownBrightness) : btnSaveAsFile.ForeColor;
                    s.Graphics.DrawIcon(new DvIcon("fa-asterisk") { IconSize = 7 }, br, new Rectangle(x, y + n, 10, 10), Devinno.Forms.DvContentAlignment.MiddleCenter);
                }
            };
            #endregion

            #region btn[F3/F4/F5...].ButtonClick    : 레더 버튼
            btnSPC.ButtonClick += (o, s) => ladder.ItemNONE();
            btnF3.ButtonClick += (o, s) => ladder.ItemIN_A();
            btnF4.ButtonClick += (o, s) => ladder.ItemIN_B();
            btnF5.ButtonClick += (o, s) => ladder.ItemLINE_H();
            btnF6.ButtonClick += (o, s) => ladder.ItemLINE_V();
            btnF7.ButtonClick += (o, s) => ladder.ItemOUT_COIL();
            btnF8.ButtonClick += (o, s) => ladder.ItemOUT_FUNC();
            btnF9.ButtonClick += (o, s) => ladder.ItemNOT();
            btnF11.ButtonClick += (o, s) => ladder.ItemRISING_EDGE();
            btnF12.ButtonClick += (o, s) => ladder.ItemFALLING_EDGE();
            #endregion

            #region btn[?]File.ButtonClick          : 새파일, 열기, 저장, 다른 이름으로 저장
            btnNewFile.ButtonClick += (o, s) => NewFile();
            btnSaveFile.ButtonClick += (o, s) => SaveFile();
            btnSaveAsFile.ButtonClick += (o, s) => SaveAsFile();
            btnOpenFile.ButtonClick += (o, s) => OpenFile();
            #endregion
            #region btnCheck.ButtonClick            : 유효성 체크
            btnCheck.ButtonClick += (o, s) =>
            {
                if (CurrentDocument != null)
                {
                    if (CurrentDocument.Edit) CurrentDocument.Save();

                    var ret = LadderTool.ValidCheck(CurrentDocument, true);
                    foreach (var v in ret) v.Message = LM.Error(v.Message); 
                    gridMessage.SetDataSource<LadderCheckMessage>(ret);
                    if (ret.Count == 0)
                        Message(LM.ValidationCheck, LM.ValidationOK);
                    else
                        Message(LM.ValidationCheck, LM.ValidationFail);
                }
            };
            #endregion
            #region lblConnection.ButtonClicked     : 연결
            lblConnection.ButtonClicked += (o, s) =>
            {
                if (!Program.DevMgr.IsConnected)
                {
                    Block = true;
                    var ip = frmConnect.ShowConnect();
                    if (ip != null) Program.DevMgr.Start(ip);
                    Block = false;
                }
                else Program.DevMgr.Stop();

                UISet();
            };
            #endregion
            #region btnUpload.ButtonClick           : 업로드
            btnUpload.ButtonClick += (o, s) =>
            {
                if (Program.DevMgr.IsConnected)
                {
                    Program.DevMgr.Upload();
                }
            };
            #endregion
            #region btnDownload.ButtonClick         : 다운로드
            btnDownload.ButtonClick += (o, s) =>
            {
                if (Program.DevMgr.IsConnected)
                {
                    if (CurrentDocument != null)
                    {
                        var ret = LadderTool.ValidCheck(CurrentDocument, true);
                        foreach (var v in ret) v.Message = LM.Error(v.Message);
                        gridMessage.SetDataSource<LadderCheckMessage>(ret);
                        if (ret.Count == 0)
                        {
                            if (CurrentDocument.Edit) CurrentDocument.Save();

                            Program.DevMgr.Download(CurrentDocument);
                        }
                        else
                            Message(LM.ValidationCheck, LM.ValidationFail);
                    }
                }
            };
            #endregion
            #region btnMonitoring.ButtonClick       : 모니터링
            btnMonitoring.ButtonClick += (o, s) =>
            {
                if (Program.DevMgr.IsConnected)
                {
                    if (Program.DevMgr.IsDebugging) Program.DevMgr.StopDebug();
                    else Program.DevMgr.StartDebug();
                }
            };
            #endregion
            #region btnDescription.ButtonClick      : 프로젝트 정보
            btnDescription.ButtonClick += (o, s) =>
            {
                if (CurrentDocument != null)
                {
                    Block = true;
                    var ret = frmDescription.ShowDescription(CurrentDocument);
                    if (ret != null)
                    {
                        CurrentDocument.Title = ret.Title;
                        CurrentDocument.Description = ret.Description;
                        CurrentDocument.Version = ret.Version;
                        CurrentDocument.Edit = true;
                    }
                    Block = false;
                }
            };
            #endregion
            #region btnSymbol.ButtonClick           : 심볼
            btnSymbol.ButtonClick += (o, s) =>
            {
                Block = true;
                var ret = frmSymbol.ShowSymbol(CurrentDocument);
                if (ret != null)
                {
                    CurrentDocument.P_Count = ret.P_Count;
                    CurrentDocument.M_Count = ret.M_Count;
                    CurrentDocument.T_Count = ret.T_Count;
                    CurrentDocument.C_Count = ret.C_Count;
                    CurrentDocument.D_Count = ret.D_Count;
                    CurrentDocument.Symbols.Clear();
                    CurrentDocument.Symbols.AddRange(ret.Symbols);

                    CurrentDocument.Edit = true;
                }
                Block = false;
            };
            #endregion
            #region btnCommunication.ButtonClick    : 통신설정
            btnCommunication.ButtonClick += (o, s) =>
            {
                Block = true;
                var ret = frmComm.ShowCommunication(CurrentDocument);
                if (ret != null)
                {
                    CurrentDocument.Communications = CryptoTool.EncodeBase64String(Serialize.JsonSerializeWithType(ret));
                    CurrentDocument.Edit = true;
                }
                Block = false;
            };
            #endregion
            #region btnReference.ButtonClick        : 라이브러리
            btnReference.ButtonClick += (o, s) =>
            {
                if (CurrentDocument != null)
                {
                    Block = true;

                    var ret = frmLibrary.ShowLibrary(CurrentDocument.Libraries);
                    if (ret != null)
                    {
                        CurrentDocument.Libraries.Clear();
                        CurrentDocument.Libraries.AddRange(ret);
                        CurrentDocument.Edit = true;
                    }

                    Block = false;
                }
            };
            #endregion
            #region btnSetting.ButtonClick          : 설정
            btnSetting.ButtonClick += (o, s) =>
            {
                Block = true;
                var ret = frmSetting.ShowSetting();
                if (ret != null)
                {
                    Program.DataMgr.ProjectFolder = ret.ProjectFolder;
                    Program.DataMgr.Language = ret.Language;
                    Program.DataMgr.SaveSetting();
                }
                Block = false;
            };
            #endregion

            #region ladder.LadderChanged            : 레더 변경
            ladder.LadderChanged += (o, s) => { if (CurrentDocument != null) CurrentDocument.Edit = true; };
            #endregion
            #region gridMessage.CellMouseClick      : 에러 클릭
            gridMessage.CellMouseClick += (o, s) =>
            {
                var sel = s.Cell.Row;
                if (sel != null && sel.Source is LadderCheckMessage)
                {
                    sel.Selected = true;
                    var v = sel.Source as LadderCheckMessage;
                    if (v.Column.HasValue && v.Row.HasValue)
                    {
                        if (ladder.DicRows.ContainsKey(v.Row.Value - 1))
                        {
                            var r = ladder.DicRows[v.Row.Value - 1];
                            while (r != null)
                            {
                                r.Expand = true;
                                r = ladder.DicRows[r.Row].Parent;
                            }
                            ladder.MakeRows();
                            var cy = ladder.Rows.IndexOf(ladder.DicRows[v.Row.Value]);
                            ladder.CurY = cy - 1;
                            ladder.CurX = v.Column.Value - 1;
                        }
                    }
                }
            };
            #endregion

            #region tsmi[DEC/HEX/BIN].Click
            tsmiDEC.Click += (o, s) => { ladder.LadderDisplayType = LadderDisplayKinds.DEC; ladder.Invalidate(); };
            tsmiHEX.Click += (o, s) => { ladder.LadderDisplayType = LadderDisplayKinds.HEX; ladder.Invalidate(); };
            tsmiBIN.Click += (o, s) => { ladder.LadderDisplayType = LadderDisplayKinds.BIN; ladder.Invalidate(); };
            #endregion
            #endregion

            #region ToolTip
            toolTip.Draw += (o, s) =>
            {
                using (var br = new SolidBrush(Color.Black))
                {
                    s.Graphics.Clear(Color.Black);
                    br.Color = Color.FromArgb(90, 90, 90);
                    s.Graphics.FillRectangle(br, new Rectangle(s.Bounds.X + 1, s.Bounds.Y + 1, s.Bounds.Width - 2, s.Bounds.Height - 2));

                    s.DrawText();
                }
            };
            #endregion

            #region Set
            ladder.Font = new Font("나눔고딕", 8);
            Theme.Animation = Theme.TouchMode = false;
            #endregion

            SetExComposited();

            UISet();

            KeyPreview = true;
            #region Language
            Program.DataMgr.LanguageChanged += (o, s) => ToolTipSet();
            #endregion
        }
        #endregion

        #region Override
        #region OnThemeDraw
        protected override void OnThemeDraw(PaintEventArgs e, DvTheme Theme)
        {
            var hTOP = pnlTop.Height + Padding.Top;
            var hBTM = Padding.Bottom + pnlStatus.Height + pnlMessage.Height;
            var rt = new Rectangle(-5, hTOP, this.Width + 10, this.Height - hTOP - hBTM);
            using (var br = new SolidBrush(pnlContent.BackColor))
            {
                e.Graphics.FillRectangle(br, rt);
            }

            using (var p = new Pen(pnlTop.BackColor))
            {
                e.Graphics.DrawLine(p, 0, pnlTop.Top - 1, this.Right, pnlTop.Top - 1);
            }
            base.OnThemeDraw(e, Theme);
        }
        #endregion
        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            ladder.Focus();
            ladder.Select();

            ToolTipSet();
            LangSet();
            base.OnLoad(e);
        }
        #endregion
        #region OnClosing
        protected override void OnClosing(CancelEventArgs e)
        {
            if (CurrentDocument != null && CurrentDocument.MustSave)
            {
                Block = true;

                var ret = Program.MessageBox.ShowMessageBoxYesNo(LM.Save, LM.SaveQuestion);
                if (ret == DialogResult.Yes) SaveFile();
                else if (ret == DialogResult.Cancel) e.Cancel = true;

                Block = false;
            }
            base.OnClosing(e);
        }
        #endregion
        #region OnKeyDown
        protected override void OnKeyDown(KeyEventArgs e)
        {
            ladder.Focus();
            base.OnKeyDown(e);
        }
        #endregion
        #region OnKeyUp
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.F10)
            {
                System.Threading.ThreadPool.QueueUserWorkItem((o) => {

                    this.Invoke(new Action(() => {

                        frmMultiDown.ShowMultiDownload();
                        
                    }));
                
                });
            }

            base.OnKeyUp(e);
        }
        #endregion
        #endregion

        #region Method
        #region NewFile
        void NewFile()
        {
            bool bCancel = false;
            if (CurrentDocument != null && CurrentDocument.MustSave)
            {
                Block = true;
                switch (Program.MessageBox.ShowMessageBoxYesNoCancel(LM.Save, LM.SaveQuestion))
                {
                    case DialogResult.Yes: SaveFile(); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: bCancel = true; break;
                }
                Block = false;
            }

            if (!bCancel)
            {
                Block = true;

                Program.InputBox.UseEnterKey = true;
                var ret = Program.InputBox.ShowString(LM.NewFile);
                if (ret != null)
                {
                    CurrentDocument = new EditorLadderDocument() { Title = ret };
                    CurrentDocument.Title = ret;

                    ladder.Ladders = CurrentDocument.Ladders;
                    ladder.Select();
                    ladder.Invalidate();

                    UISet();
                }
                Program.InputBox.UseEnterKey = false;

                Block = false;
            }
        }
        #endregion
        #region OpenFile
        void OpenFile()
        {
            bool bCancel = false;
            if (CurrentDocument != null && CurrentDocument.MustSave)
            {
                Block = true;

                switch (Program.MessageBox.ShowMessageBoxYesNoCancel(LM.Save, LM.SaveQuestion))
                {
                    case DialogResult.Yes: SaveFile(); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: bCancel = true; break;
                }

                Block = false;
            }

            if (!bCancel)
            {
                Block = true;
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = LM.Open;
                    ofd.InitialDirectory = Program.DataMgr.ProjectFolder;
                    ofd.Multiselect = false;
                    ofd.Filter = "Devinno Ladder File|*.dld";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        CurrentDocument = Serialize.JsonDeserializeWithTypeFromFile<EditorLadderDocument>(ofd.FileName);
                        CurrentDocument.FileName = ofd.FileName;
                        ladder.Ladders = CurrentDocument.Ladders;
                        try
                        {
                            ladder.RowCount = Convert.ToInt32(Math.Ceiling(CurrentDocument.Ladders.Max(x => x.Row) / 10.0)) * 10;
                        }
                        catch { ladder.RowCount = 50; }
                        ladder.Invalidate();
                        ladder.Select();
                        UISet();
                    }
                }
                Block = false;
            }
        }
        #endregion
        #region SaveFile
        void SaveFile()
        {
            if (CurrentDocument != null)
            {
                if (!string.IsNullOrWhiteSpace(CurrentDocument.FileName) && File.Exists(CurrentDocument.FileName)) Block = true;

                try
                {
                    CurrentDocument.Save();
                }
                catch (UnauthorizedAccessException)
                {
                    Program.MessageBox.ShowMessageBoxOk(LM.Save, LM.SavePermissions);
                }

                if (Block) Block = false;
            }
        }
        #endregion
        #region SaveAsFile
        void SaveAsFile()
        {
            if (CurrentDocument != null)
            {
                Block = true;

                try
                {
                    CurrentDocument.SaveAs();
                }
                catch (UnauthorizedAccessException)
                {
                    Program.MessageBox.ShowMessageBoxOk(LM.Save, LM.SavePermissions);
                }

                Block = false;
            }
        }
        #endregion
        #region UploadFile
        public void UploadFile(LadderDocument v)
        {
            bool bCancel = false;
            if (CurrentDocument != null && CurrentDocument.MustSave)
            {
                switch (Program.MessageBox.ShowMessageBoxYesNoCancel(LM.Save, LM.SaveQuestion))
                {
                    case DialogResult.Yes: SaveFile(); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: bCancel = true; break;
                }
            }

            if (!bCancel)
            {
                CurrentDocument = new EditorLadderDocument()
                {
                    Title = v.Title,
                    Description = v.Description,
                    P_Count = v.P_Count,
                    M_Count = v.M_Count,
                    T_Count = v.T_Count,
                    C_Count = v.C_Count,
                    D_Count = v.D_Count,

                    Communications = v.Communications,
                };

                CurrentDocument.Ladders.Clear();
                CurrentDocument.Ladders.AddRange(v.Ladders);

                CurrentDocument.Symbols.Clear();
                CurrentDocument.Symbols.AddRange(v.Symbols);


                ladder.Ladders = CurrentDocument.Ladders;
                ladder.RowCount = CurrentDocument.Ladders.Max(x => x.Row) + 1;
                ladder.Select();
                ladder.Focus();
                ladder.Invalidate();

                UISet();
            }
        }
        #endregion

        #region Message
        public void Message(string Title, string Message)
        {
            Block = true;
            Program.MessageBox.ShowMessageBoxOk(Title, Message);
            Block = false;
        }
        #endregion
        #region Debug
        public void Debug(List<DebugInfo> v) => ladder.SetDebug(v);
        #endregion

        #region ToolTipSet
        void ToolTipSet()
        {
            toolTip.SetToolTip(btnUpload, LM.Upload);
            toolTip.SetToolTip(btnSymbol, LM.Symbol);
            toolTip.SetToolTip(btnSaveFile, LM.Save);
            toolTip.SetToolTip(btnSaveAsFile, LM.SaveAs);
            toolTip.SetToolTip(btnOpenFile, LM.Open);
            toolTip.SetToolTip(btnNewFile, LM.NewFile);
            toolTip.SetToolTip(btnMonitoring, LM.Monitoring);
            toolTip.SetToolTip(btnDownload, LM.Download);
            toolTip.SetToolTip(btnDescription, LM.ProjectDescription);
            toolTip.SetToolTip(btnCommunication, LM.Communication);
            toolTip.SetToolTip(btnCheck, LM.ValidationCheck);
            toolTip.SetToolTip(btnReference, LM.Library);
        }
        #endregion
        #region LandSet
        void LangSet()
        {
            lblConnection.Title = LM.Device;
            lblDeviceState.Text = LM.DeviceState;
            lblConnection.Button = Program.DevMgr.IsConnected ? LM.Disconnect : LM.Connect;

            lblCursorPosition.Text = CurrentDocument != null ? $"{LM.Col} : {(ladder.CurX + 1)}        {LM.Row} : {(ladder.CurRow + 1)}" : "";
            Title = LM.AppTitle + (CurrentDocument != null ? "  :  " + CurrentDocument.DisplayTitle : "");

            gridMessage.Columns[0].HeaderText = LM.Row;
            gridMessage.Columns[1].HeaderText = LM.Col;
            gridMessage.Columns[2].HeaderText = LM.Message;

            if (Program.DevMgr != null)
            {
                var s = "";
                switch (Program.DevMgr.DeviceState)
                {
                    case EngineState.DISCONNECTED: s = LM.StateDisconnected; break;
                    case EngineState.STANDBY: s = LM.StateStandby; break;
                    case EngineState.RUN: s = LM.StateRun; break;
                    case EngineState.DOWNLOADING: s = LM.StateDownloading; break;
                    case EngineState.ERROR: s = LM.StateError; break;
                }
                lblState.Text = s;
            }
        }
        #endregion
        #region UISet
        void UISet()
        {
            bool IsConnected = Program.DevMgr.IsConnected;
            bool IsDebugging = Program.DevMgr.IsDebugging;

            lblConnection.Value = IsConnected ? Program.DevMgr.TargetIP : "";

            LangSet();

            btnMonitoring.ButtonColor = IsConnected && IsDebugging ? Color.Teal : Theme.ButtonColor;

            ladder.Visible = CurrentDocument != null;
            btnSaveFile.Enabled = CurrentDocument != null;
            btnSaveAsFile.Enabled = CurrentDocument != null;
            btnCheck.Enabled = CurrentDocument != null && !IsDebugging;
            btnDescription.Enabled = CurrentDocument != null && !IsDebugging;
            btnSymbol.Enabled = CurrentDocument != null && !IsDebugging;
            btnCommunication.Enabled = CurrentDocument != null && !IsDebugging;
            btnReference.Enabled = CurrentDocument != null && !IsDebugging;
            pnlLD.Enabled = CurrentDocument != null && !IsDebugging && ladder.Editable;
            gridMessage.Enabled = CurrentDocument != null;

            ladder.Debug = IsConnected && IsDebugging;

            var st = Program.DevMgr?.DeviceState ?? EngineState.DISCONNECTED;
            var b1 = st == EngineState.RUN || st == EngineState.STANDBY;
            var b2 = st == EngineState.ERROR;

            btnUpload.Enabled = b1 && IsConnected && !IsDebugging;
            btnDownload.Enabled = (b1 || b2) && (IsConnected && CurrentDocument != null) && !IsDebugging;
            btnMonitoring.Enabled = b1 && IsConnected && CurrentDocument != null;

            #region SizeChanged
            if (szold != this.Size)
            {
                szold = this.Size;
                Invalidate();
            }
            #endregion
        }
        #endregion
        #endregion
    }
}
