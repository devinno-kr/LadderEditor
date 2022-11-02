/*
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Extensions;
using Devinno.Forms.Themes;
using Devinno.Forms.Utils;
using Devinno.PLC.Ladder;
using Devinno.Tools;
using GuiLabs.Undo;
using LadderEditor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LadderEditor.Controls
{
    public class LadderEditorControl : DvControl
    {
        #region Const
        const int NormalFontSize = 8;
        const int AliasFontSize = 8;
        #endregion

        #region Properties
        #region NumberBoxWidth
        private int nNumberBoxWidth = 100;
        public int NumberBoxWidth
        {
            get => nNumberBoxWidth;
            set
            {
                if (nNumberBoxWidth != value)
                {
                    nNumberBoxWidth = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #region RowHeight
        private int nRowHeight = 60;
        public int RowHeight
        {
            get => nRowHeight;
            set
            {
                if (nRowHeight != value)
                {
                    nRowHeight = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #region ScrollPosition
        public double ScrollPosition
        {
            get => scroll.ScrollPosition;
            set
            {
                if (scroll.ScrollPosition != value)
                {
                    scroll.ScrollPosition = value;
                    Invalidate();
                }
            }
        }
        #endregion

        #region Color
        #region BoxColor
        private Color? cBoxColor = null;
        public Color? BoxColor
        {
            get => cBoxColor;
            set
            {
                if (cBoxColor != value)
                {
                    cBoxColor = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #region NumberBoxColor
        private Color? cNumberBoxColor = null;
        public Color? NumberBoxColor
        {
            get => cNumberBoxColor;
            set
            {
                if (cNumberBoxColor != value)
                {
                    cNumberBoxColor = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #endregion
        #region RowCount
        private int nRowCount = 50;
        public int RowCount
        {
            get => nRowCount;
            set
            {
                if (nRowCount != value)
                {
                    nRowCount = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #region ColumnCount
        private int nColumnCount = 15;
        public int ColumnCount
        {
            get => nColumnCount;
            set
            {
                if (nColumnCount != value)
                {
                    nColumnCount = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #region Ladders
        List<LadderItem> lstLadder = new List<LadderItem>();
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<LadderItem> Ladders
        {
            get { return lstLadder; }
            set
            {
                if (lstLadder != value)
                {
                    lstLadder = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #region CurX
        private int nCurX = 0;
        public int CurX
        {
            get { return nCurX; }
            set
            {
                if (nCurX != value)
                {
                    nCurX = value;
                    if (nCurX < 0) nCurX = 0;
                    if (nCurX > ColumnCount - 1) nCurX = ColumnCount - 1;
                    if (!ShiftKey) { seldown = null; selup = null; }
                    Invalidate();
                }
            }
        }
        #endregion
        #region CurY
        private int nCurY = 0;
        public int CurY
        {
            get { return nCurY; }
            set
            {
                if (nCurY != value)
                {
                    bool Large = nCurY < value;
                    nCurY = value;
                    if (nCurY < 0) nCurY = 0;
                    if (nCurY > RowCount - 1) RowCount = nCurY + 1;

                    var th = GetContentBounds().Height;
                    if ((CurY * RowHeight) + RowHeight > ScrollPosition + th) ScrollPosition = (((CurY * RowHeight) + RowHeight) - th);
                    if ((CurY * RowHeight) < ScrollPosition) ScrollPosition = CurY * RowHeight;

                    if (!ShiftKey) { seldown = null; selup = null; }
                    Invalidate();
                }
            }
        }
        #endregion
        #region CanUndo / CanRedo
        public bool CanUndo => actmgr.CanUndo;
        public bool CanRedo => actmgr.CanRedo;
        #endregion
        #region ShiftKey / ControlKey / AltKey
        public bool ShiftKey => (ModifierKeys & Keys.Shift) == Keys.Shift;
        public bool ControlKey => (ModifierKeys & Keys.Control) == Keys.Control;
        public bool AltKey => (ModifierKeys & Keys.Alt) == Keys.Alt;
        #endregion
        #region Debug
        private bool bDebug = false;
        public bool Debug
        {
            get => bDebug;
            set
            {
                if (bDebug != value)
                {
                    bDebug = value;
                    if (bDebug) StartDebug();
                    else StopDebug();
                    Invalidate();
                }
            }
        }
        #endregion
        #region LadderDisplayType
        private LadderDisplayKinds eLadderDisplayType = LadderDisplayKinds.DEC;
        public LadderDisplayKinds LadderDisplayType
        {
            get => eLadderDisplayType;
            set
            {
                if (eLadderDisplayType != value)
                {
                    eLadderDisplayType = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #region Editable
        public bool Editable => Buffer.Count == 0;
        #endregion
        #endregion

        #region Member Variable
        #region Scroll
        private Scroll scroll = new Scroll();
        private Point downPoint;
        private DateTime downTime;
        #endregion
        #region Dialogs
        DvMessageBox MessageBox = new DvMessageBox();
        #endregion
        #region Drag
        Point? dragpos = null;
        object dragitem = null;
        #endregion
        #region ActionManager
        ActionManager actmgr = new ActionManager();
        #endregion
        #region Buffer
        bool bCutBuffer = false;
        List<LadderItem> Buffer = new List<LadderItem>();
        DateTime bufferSetTime = DateTime.Now;
        #endregion
        #region Select Range
        Point? seldown = null;
        Point? selmove = null;
        Point? selup = null;
        Point selprev;
        #endregion
        #region Form
        LadderEditForm frmEdit = new LadderEditForm();
        #endregion
        #region Timer
        Timer tmr = new Timer();
        Timer tmr2 = new Timer();
        #endregion
        #region MonitorValues
        Dictionary<string, MonitorValue> MonitorValues = new Dictionary<string, MonitorValue>();
        #endregion
        #endregion

        #region Event 
        public event EventHandler LadderChanged;
        #endregion

        #region Constructor
        public LadderEditorControl()
        {
            SetStyle(ControlStyles.Selectable, true);
            UpdateStyles();

            #region Init
            TabStop = true;
            AllowDrop = true;
            Size = new Size(300, 300);
            #endregion

            #region Scroll
            //scroll.TouchMode = true;
            scroll.Direction = ScrollDirection.Vertical;
            scroll.ScrollChanged += (o, s) => this.Invoke(new Action(() => Invalidate()));
            scroll.GetScrollTotal = () => RowCount * RowHeight;
            scroll.GetScrollTick = () => RowHeight;
            scroll.GetScrollView = () => GetContentBounds().Height;
            #endregion

            #region Timer
            tmr.Tick += new EventHandler((o, s) =>
            {
                if (seldown.HasValue && selmove.HasValue && !selup.HasValue && !ShiftKey)
                {
                    var v = this.PointToClient(MousePosition);
                    if (v.Y < 0 && selmove.HasValue)
                    {
                        selmove = new Point(selmove.Value.X, (selmove.Value.Y - 1 > 0 ? selmove.Value.Y - 1 : 0));
                        int CurY = selmove.Value.Y;
                        var th = GetContentBounds().Height;
                        if ((CurY * RowHeight) + RowHeight > ScrollPosition + th) ScrollPosition = (((CurY * RowHeight) + RowHeight) - th);
                        if ((CurY * RowHeight) < ScrollPosition) ScrollPosition = CurY * RowHeight;

                    }
                    if (v.Y > this.Height)
                    {
                        selmove = new Point(selmove.Value.X, (selmove.Value.Y + 1 < RowCount ? selmove.Value.Y + 1 : RowCount - 1));
                        int CurY = selmove.Value.Y;
                        var th = GetContentBounds().Height;
                        if ((CurY * RowHeight) + RowHeight > ScrollPosition + th) ScrollPosition = (((CurY * RowHeight) + RowHeight) - th);
                        if ((CurY * RowHeight) < ScrollPosition) ScrollPosition = CurY * RowHeight;
                    }
                }
            });
            tmr.Interval = 10;
            tmr.Enabled = true;
            #endregion

            #region Timer2
            tmr2.Interval = 10;
            tmr2.Tick += (o, s) => { if (Debug) Invalidate(); };
            tmr2.Enabled = true;
            #endregion

            Font = new Font("나눔고딕", NormalFontSize);
        }
        #endregion

        #region Override
        #region OnThemeDraw
        protected override void OnThemeDraw(PaintEventArgs e, DvTheme Theme)
        {
            #region Color
            var BoxColor = this.BoxColor ?? Theme.ListBackColor;
            var NumberSectionColor = this.NumberBoxColor ?? Theme.InputColor;
            var BorderColor = Theme.GetBorderColor(NumberSectionColor, BackColor);
            #endregion
            #region Set
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var mp = this.PointToClient(MousePosition);
            var LD_ROW = Ladders.ToLookup(x => x.Row);

            AfterItem after = null;
            #endregion
            #region Init
            var p = new Pen(Color.Black, 2);
            var br = new SolidBrush(Color.Black);
            var ftb = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
            #endregion

            Areas((rtContent, rtNumber, rtBox, rtScroll) =>
            {
                #region Result Calc
                Dictionary<string, List<List<LadderItem>>> result = new Dictionary<string, List<List<LadderItem>>>();
                if (Debug)
                {
                    var r = LadderTool.Build(Ladders);
                    result = r.ValidNodes;
                    foreach (var v in Ladders)
                    {
                        v.MonitorV = false;
                        v.PrevMonitorV = v.Col == 0;
                        v.VerticalMonitorV = v.MonitorV;
                    }

                    #region Result Calc
                    foreach (var k in result.Keys)
                    {
                        foreach (var vls in result[k])
                        {
                            foreach (var _v in vls)
                            {
                                int iprev = vls.IndexOf(_v) - 1;
                                int inext = vls.IndexOf(_v) + 1;

                                var pv = iprev >= 0 ? GetLadder(vls[iprev].Row, vls[iprev].Col) : null;
                                var nv = inext < vls.Count ? GetLadder(vls[inext].Row, vls[inext].Col) : null;

                                var v = GetLadder(_v.Row, _v.Col);
                                if (v != null)
                                {
                                    if (pv != null) v.PrevMonitorV = pv.MonitorV;
                                    switch (v.ItemType)
                                    {
                                        case LadderItemType.NONE:
                                        case LadderItemType.LINE_H:
                                            {
                                                v.MonitorV |= v.PrevMonitorV;
                                            }
                                            break;

                                        case LadderItemType.IN_A:
                                        case LadderItemType.IN_B:
                                        case LadderItemType.OUT_COIL:
                                        case LadderItemType.OUT_FUNC:
                                            {
                                                v.MonitorV |= (v.PrevMonitorV && v.Monitor);
                                            }
                                            break;
                                        case LadderItemType.RISING_EDGE:
                                        case LadderItemType.FALLING_EDGE:
                                        case LadderItemType.NOT:
                                            {
                                                v.MonitorV = v.Monitor;
                                            }
                                            break;
                                    }
                                    v.VerticalMonitorV |= v.MonitorV;

                                }
                            }
                        }
                    }
                    #endregion

                    foreach (var v in Ladders)
                    {
                        if (v.VerticalLine)
                        {
                            var nv = GetLadder(v.Row + 1, v.Col);
                            var nv2 = GetLadder(v.Row + 1, v.Col - 1);
                            if ((nv != null && !nv.MonitorV) || (nv == null && nv2 != null && !nv2.MonitorV)) v.VerticalMonitorV = false;
                        }
                    }
                }
                #endregion

                #region Draw
                #region Box
                e.Graphics.Clear(BackColor);
                Theme.DrawBox(e.Graphics, rtNumber, NumberSectionColor, BorderColor, RoundType.L, Box.FlatBox(true, true));
                Theme.DrawBox(e.Graphics, rtBox, BoxColor, BorderColor, RoundType.Rect, Box.FlatBox(true, true));
                #endregion

                #region Cursor
                var curw = (double)rtBox.Width / (double)ColumnCount;
                var rtCur = new RectangleF(rtBox.X + Convert.ToSingle(CurX * curw), rtBox.Y + (CurY * RowHeight) - Convert.ToSingle(scroll.ScrollPosition), Convert.ToSingle(curw), RowHeight);
                rtCur.Inflate(-1, -1);

                e.Graphics.SetClip(rtBox);

                p.Color = Focused ? Color.Cyan : Color.FromArgb(60, Color.Cyan);
                p.Width = 1;
                p.DashStyle = DashStyle.Solid;
                e.Graphics.DrawRectangle(p, rtCur);

                e.Graphics.ResetClip();
                #endregion

                #region Scroll
                br.Color = Theme.ScrollBarColor;
                Theme.DrawBox(e.Graphics, rtScroll, Theme.ScrollBarColor, BorderColor, RoundType.R, Box.FlatBox(true, true));

                var cCur = Theme.ScrollCursorOffColor;
                if (scroll.IsScrolling || scroll.IsTouchMoving) cCur = Theme.ScrollCursorOnColor;

                var rtcur = scroll.GetScrollCursorRect(rtScroll);
                if (rtcur.HasValue) Theme.DrawBox(e.Graphics, rtcur.Value, cCur, BorderColor, RoundType.All, BoxStyle.Fill);
                #endregion

                #region NumberBox / Items
                var sidx = Convert.ToInt32(Math.Floor((double)ScrollPosition / (double)RowHeight));
                var rcnt = Convert.ToInt32(Math.Ceiling((double)rtBox.Height / (double)RowHeight));
                e.Graphics.SetClip(rtContent);

                for (int i = sidx - 1; i < sidx + rcnt; i++)
                {
                    var y = Convert.ToInt32(-ScrollPosition + (i * RowHeight));
                    var rtNumBox = new RectangleF(rtNumber.Left, y, rtNumber.Width, RowHeight);

                    #region Number
                    {
                        var ft = i == CurY ? ftb : Font;
                        var c = i == CurY ? Color.White : Color.FromArgb(120, 120, 120);
                        Theme.DrawText(e.Graphics, (i + 1).ToString(), ft, c, rtNumBox);
                    }
                    #endregion
                    #region Item
                    if (LD_ROW.Contains(i))
                    {
                        foreach (var v in LD_ROW[i])
                        {
                            var x = Convert.ToInt32(rtNumber.Right + (v.Col * curw));
                            var rt = new Rectangle(x, y, Convert.ToInt32(curw), RowHeight);
                            var sz = e.Graphics.MeasureString(v.Code, Font);

                            if (CollisionTool.Check(rt, mp) && (rt.Width < sz.Width))
                            {
                                after = new AfterItem() { item = v, Bounds = rt };
                            }
                            else
                            {
                                if (!Debug)
                                {
                                    if (bCutBuffer && Buffer.Contains(v)) PaintItem(e.Graphics, Color.FromArgb(120, Color.White), rtBox, rt, v, mp);
                                    else PaintItem(e.Graphics, Color.White, rtBox, rt, v, mp);
                                }
                                else
                                {
                                    PaintDebug(e.Graphics, rt, v);
                                }
                            }
                        }
                    }
                    #endregion
                }

                e.Graphics.ResetClip();
                #endregion

                #region Select Range
                if (seldown.HasValue && selmove.HasValue && !selup.HasValue)
                {
                    int minx = Math.Min(seldown.Value.X, selmove.Value.X);
                    int miny = Math.Min(seldown.Value.Y, selmove.Value.Y);
                    int maxx = Math.Max(seldown.Value.X, selmove.Value.X);
                    int maxy = Math.Max(seldown.Value.Y, selmove.Value.Y);

                    int w = maxx - minx + 1;
                    int h = maxy - miny + 1;


                    var x = Convert.ToInt32(rtNumber.Right + (minx * curw));
                    var y = Convert.ToInt32((double)rtContent.Y + ((double)miny * RowHeight)) - Convert.ToInt32(ScrollPosition);
                    Rectangle rtSel = new Rectangle(x, y, Convert.ToInt32(curw * w), RowHeight * h);
                    rtSel.Inflate(-1, -1);

                    p.Color = Color.Yellow;
                    p.DashStyle = DashStyle.Dash;
                    br.Color = Color.FromArgb(20, Color.Yellow);
                    e.Graphics.FillRectangle(br, rtSel);
                    e.Graphics.DrawRectangle(p, rtSel);
                }
                else if (seldown.HasValue && selup.HasValue)
                {
                    int minx = Math.Min(seldown.Value.X, selup.Value.X);
                    int miny = Math.Min(seldown.Value.Y, selup.Value.Y);
                    int maxx = Math.Max(seldown.Value.X, selup.Value.X);
                    int maxy = Math.Max(seldown.Value.Y, selup.Value.Y);

                    int w = maxx - minx + 1;
                    int h = maxy - miny + 1;

                    var x = Convert.ToInt32(rtNumber.Right + (minx * curw));
                    var y = Convert.ToInt32((double)rtContent.Y + ((double)miny * RowHeight)) - Convert.ToInt32(ScrollPosition);
                    Rectangle rtSel = new Rectangle(x, y, Convert.ToInt32(curw * w), RowHeight * h);
                    rtSel.Inflate(-1, -1);

                    p.Color = Color.White;
                    p.DashStyle = DashStyle.Dash;
                    br.Color = Color.FromArgb(20, Color.White);
                    e.Graphics.FillRectangle(br, rtSel);
                    e.Graphics.DrawRectangle(p, rtSel);
                }
                #endregion

                #region Buffer Range
                if (Buffer.Count > 0)
                {
                    var minx = Buffer.Min(_x => _x.Col);
                    var maxx = Buffer.Max(_x => _x.Col);
                    var miny = Buffer.Min(_x => _x.Row);
                    var maxy = Buffer.Max(_x => _x.Row);
                    var gapx = CurX - minx;
                    var gapy = CurY - miny;

                    int w = maxx - minx + 1;
                    int h = maxy - miny + 1;

                    Color csel = Color.Magenta;

                    foreach (var v in Buffer)
                    {
                        var x = Convert.ToInt32(rtNumber.Right + ((v.Col + gapx) * curw));
                        var y = Convert.ToInt32((double)rtContent.Y + ((double)(v.Row + gapy) * RowHeight)) - Convert.ToInt32(ScrollPosition);
                        Rectangle rtRange = new Rectangle(x, y, Convert.ToInt32(curw), RowHeight);
                        Color c = csel;
                        if (gapx + maxx > ColumnCount - 1 || gapy + maxy > RowCount - 1) c = Color.Red;
                        PaintItem(e.Graphics, c, rtBox, rtRange, v, mp);
                    }
                }
                #endregion

                #region Border
                p.DashStyle = DashStyle.Solid;
                p.Color = Color.FromArgb(15, 15, 15);
                Theme.DrawBox(e.Graphics, rtContent, NumberSectionColor, p.Color, RoundType.All, BoxStyle.Border);
                e.Graphics.DrawLine(p, rtBox.Left, rtBox.Top, rtBox.Left, rtBox.Bottom);
                e.Graphics.DrawLine(p, rtBox.Right, rtBox.Top, rtBox.Right, rtBox.Bottom);
                #endregion

                #region AfterDraw
                if (after != null)
                {
                    var v = after.item;
                    var rt = after.Bounds;
                    if (!Debug)
                    {
                        if (bCutBuffer && Buffer.Contains(v)) PaintItem(e.Graphics, Color.FromArgb(120, Color.White), rtBox, rt, v, mp);
                        else PaintItem(e.Graphics, Color.White, rtBox, rt, v, mp);
                    }
                    else
                    {
                        PaintDebug(e.Graphics, rt, v);
                    }
                }
                #endregion
                #endregion
            });

            #region Dispose
            br.Dispose();
            p.Dispose();
            ftb.Dispose();
            #endregion
            base.OnThemeDraw(e, Theme);
        }
        #endregion

        #region OnMouseWheel
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Areas((rtContent, rtNumber, rtBox, rtScroll) => { scroll.MouseWheel(e.Delta, rtScroll); });
            Invalidate();
            base.OnMouseWheel(e);
        }
        #endregion
        #region OnMouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                Focus();
                Areas((rtContent, rtNumber, rtBox, rtScroll) =>
                {
                    #region Scroll
                    scroll.MouseDown(e.X, e.Y, rtScroll);
                    if (scroll.TouchMode && CollisionTool.Check(rtBox, e.Location)) scroll.TouchDown(e.X, e.Y);

                    if (CollisionTool.Check(rtBox, e.Location))
                    {
                        downPoint = e.Location;
                        downTime = DateTime.Now;
                    }
                    #endregion

                    if (!Debug)
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            var p = GetCurPos(e.X, e.Y);
                            if (p.HasValue)
                            {
                                selprev = new Point(CurX, CurY);
                                CurX = p.Value.X; CurY = p.Value.Y;
                                seldown = new Point(CurX, CurY);
                                selmove = new Point(CurX, CurY);
                                selup = null;
                            }
                        }
                    }
                    else
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            var p = GetCurPos(e.X, e.Y);
                            if (p.HasValue)
                            {
                                CurX = p.Value.X; CurY = p.Value.Y;
                            }
                        }
                    }
                });

                Invalidate();
            }
            base.OnMouseDown(e);
        }
        #endregion
        #region OnMouseMove
        protected override void OnMouseMove(MouseEventArgs e)
        {
            bool bInv = false;

            if (!DesignMode)
            {
                Areas((rtContent, rtNumber, rtBox, rtScroll) =>
                {
                    #region Scroll
                    scroll.MouseMove(e.X, e.Y, rtScroll);
                    if (scroll.TouchMode) scroll.TouchMove(e.X, e.Y);
                    if (scroll.IsScrolling) bInv = true;
                    if (scroll.TouchMode && scroll.IsTouchScrolling) bInv = true;
                    #endregion

                    if (!Debug)
                    {
                        #region Select Range
                        if (seldown.HasValue)
                        {
                            var v = GetCurPos(e.X, e.Y);
                            if (v.HasValue) selmove = v.Value;
                            bInv = true;
                        }
                        #endregion
                    }

                    if (GetCurPos(e.X, e.Y).HasValue) bInv = true;
                });
            }

            if (bInv) Invalidate();
            base.OnMouseMove(e);
        }
        #endregion
        #region OnMouseUp
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                Areas((rtContent, rtNumber, rtBox, rtScroll) =>
                {
                    #region Scroll
                    scroll.MouseUp(e.X, e.Y);
                    if (scroll.TouchMode && CollisionTool.Check(rtBox, e.Location)) scroll.TouchUp(e.X, e.Y);
                    #endregion

                    if (!Debug)
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            #region Select Range
                            if (seldown.HasValue)
                            {
                                var v = GetCurPos(e.X, e.Y);
                                if (v.HasValue)
                                {
                                    selup = new Point(v.Value.X, v.Value.Y);
                                }
                            }
                            if (seldown.HasValue && selup.HasValue && seldown.Value.X == selup.Value.X && seldown.Value.Y == selup.Value.Y)
                            {
                                if (ShiftKey)
                                {
                                    var v = GetCurPos(e.X, e.Y);
                                    if (v.HasValue)
                                    {
                                        seldown = new Point(selprev.X, selprev.Y);
                                        selup = new Point(v.Value.X, v.Value.Y);
                                        selmove = null;
                                    }
                                }
                                else
                                {
                                    selup = null; selmove = null; seldown = null;
                                }
                            }
                            Invalidate();
                            #endregion
                        }
                    }
                });
                Invalidate();
            }
            base.OnMouseUp(e);
        }
        #endregion

        #region ProcessCmdKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Focused)
            {
                if (msg.Msg == 0x100)
                {
                    if (Buffer.Count == 0)
                    {
                        switch (keyData)
                        {
                            #region Move
                            case Keys.Up: MoveUp(); break;
                            case Keys.Down: MoveDown(); break;
                            case Keys.Left: MoveLeft(); break;
                            case Keys.Right: MoveRight(); break;
                            case Keys.PageUp: MovePageUp(); break;
                            case Keys.PageDown: MovePageDown(); break;
                            case Keys.Home: MoveHome(); break;
                            case Keys.End: MoveEnd(); break;

                            case Keys.Shift | Keys.Up: MoveShiftUp(); break;
                            case Keys.Shift | Keys.Down: MoveShiftDown(); break;
                            case Keys.Shift | Keys.Left: MoveShiftLeft(); break;
                            case Keys.Shift | Keys.Right: MoveShiftRight(); break;
                            case Keys.Shift | Keys.PageUp: MoveShiftPageUp(); break;
                            case Keys.Shift | Keys.PageDown: MoveShiftPageDown(); break;
                            case Keys.Shift | Keys.Home: MoveShiftHome(); break;
                            case Keys.Shift | Keys.End: MoveShiftEnd(); break;

                            case Keys.Control | Keys.Right: MoveControlRight(); break;
                            case Keys.Control | Keys.Left: MoveControlLeft(); break;
                            case Keys.Control | Keys.Up: MoveControlUp(); break;
                            case Keys.Control | Keys.Down: MoveControlDown(); break;
                            #endregion
                            #region Item
                            case Keys.Space: ItemNONE(); break;
                            case Keys.F3: ItemIN_A(); break;
                            case Keys.F4: ItemIN_B(); break;
                            case Keys.F5: ItemLINE_H(); break;
                            case Keys.F6: ItemLINE_V(); break;
                            case Keys.F7: ItemOUT_COIL(); break;
                            case Keys.F8: ItemOUT_FUNC(); break;
                            case Keys.F9: ItemNOT(); break;
                            case Keys.F11: ItemRISING_EDGE(); break;
                            case Keys.F12: ItemFALLING_EDGE(); break;
                            #endregion
                            #region Undo / Redo
                            case Keys.Control | Keys.Z: Undo(); break;
                            case Keys.Control | Keys.Y: Redo(); break;
                            #endregion
                            #region Escape
                            case Keys.Escape:
                                {
                                    if (bCutBuffer) Undo();
                                    Buffer.Clear();
                                    bCutBuffer = false;
                                    Invalidate();
                                }
                                break;
                            #endregion
                            #region Copy / Cut / Paste
                            case Keys.Control | Keys.C: Copy(); break;
                            case Keys.Control | Keys.X: Cut(); break;
                            case Keys.Control | Keys.V: Paste(); break;
                            #endregion
                            #region Enter : Paste
                            case Keys.Enter:
                                if (Buffer.Count > 0) Paste();
                                break;
                            #endregion
                            #region Cell Insert / Delete
                            case Keys.Insert: CellInsert(); break;
                            case Keys.Delete:
                                {
                                    var sels = GetSelectItem();
                                    if (sels.Count <= 1) CellDelete();
                                    else Delete();
                                }
                                break;
                            #endregion
                            #region Line Insert / Delete
                            case Keys.Shift | Keys.Insert: LineInsert(); break;
                            case Keys.Shift | Keys.Delete: LineDelete(); break;
                                #endregion
                        }
                    }
                    else
                    {
                        switch (keyData)
                        {
                            #region Move
                            case Keys.Up: MoveUp(); break;
                            case Keys.Down: MoveDown(); break;
                            case Keys.Left: MoveLeft(); break;
                            case Keys.Right: MoveRight(); break;
                            case Keys.PageUp: MovePageUp(); break;
                            case Keys.PageDown: MovePageDown(); break;
                            case Keys.Home: MoveHome(); break;
                            case Keys.End: MoveEnd(); break;

                            case Keys.Shift | Keys.Up: MoveShiftUp(); break;
                            case Keys.Shift | Keys.Down: MoveShiftDown(); break;
                            case Keys.Shift | Keys.Left: MoveShiftLeft(); break;
                            case Keys.Shift | Keys.Right: MoveShiftRight(); break;
                            case Keys.Shift | Keys.PageUp: MoveShiftPageUp(); break;
                            case Keys.Shift | Keys.PageDown: MoveShiftPageDown(); break;
                            case Keys.Shift | Keys.Home: MoveShiftHome(); break;
                            case Keys.Shift | Keys.End: MoveShiftEnd(); break;

                            case Keys.Control | Keys.Right: MoveControlRight(); break;
                            case Keys.Control | Keys.Left: MoveControlLeft(); break;
                            case Keys.Control | Keys.Up: MoveControlUp(); break;
                            case Keys.Control | Keys.Down: MoveControlDown(); break;
                            #endregion
                            #region Escape
                            case Keys.Escape:
                                {
                                    if (bCutBuffer) Undo();
                                    Buffer.Clear();
                                    bCutBuffer = false;
                                    Invalidate();
                                }
                                break;
                            #endregion
                            #region Copy / Cut / Paste
                            case Keys.Control | Keys.V: Paste(); break;
                            #endregion
                            #region Enter : Paste
                            case Keys.Enter:
                                if (Buffer.Count > 0) Paste();
                                break;
                                #endregion
                        }
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        #region OnKeyUp
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Focused)
            {
                if (!Debug)
                {
                    #region Shift Clear
                    if (e.KeyCode == Keys.ShiftKey)
                    {
                        if (!selup.HasValue && selmove.HasValue) selup = new Point(selmove.Value.X, selmove.Value.Y);
                        if (seldown.HasValue && selup.HasValue && seldown.Value.X == selup.Value.X && seldown.Value.Y == selup.Value.Y) { selup = null; selmove = null; seldown = null; }
                        Invalidate();
                    }
                    #endregion
                    #region Find
                    if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.F)
                    {
                        FormSearch frm = new FormSearch();
                        frm.ShowSearch(this);
                    }
                    #endregion
                    #region Enter
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (Buffer.Count == 0 && (DateTime.Now - bufferSetTime).TotalSeconds >= 0.2)
                        {
                            var frm = FindForm() as DvForm;
                            var v = GetLadder(CurY, CurX);
                            if (v != null)
                            {

                                if (frm != null) frm.Block = true;

                                var code = frmEdit.ShowLadderCode(v);
                                if (code != null) SetCode(v, code);

                                if (frm != null) frm.Block = false;
                            }
                            else
                            {
                                if (frm != null) frm.Block = true;

                                var code = frmEdit.ShowLadderCode(v);
                                if (code != null)
                                {
                                    AddLadderAction(new LadderItem() { Code = code, Col = CurX, Row = CurY, ItemType = LadderItemType.NONE, VerticalLine = false });
                                }

                                if (frm != null) frm.Block = false;
                            }
                        }
                    }
                    #endregion
                }
                Invalidate();
            }
            base.OnKeyUp(e);
        }
        #endregion
        #endregion

        #region Method
        #region Areas
        void Areas(Action<RectangleF, RectangleF, RectangleF, RectangleF> act)
        {
            var scwh = Convert.ToInt32(Scroll.SC_WH);
            var rtContent = GetContentBounds();
            var rtNumber = new RectangleF(rtContent.Left, rtContent.Top, NumberBoxWidth, rtContent.Height);
            var rtBox = new RectangleF(rtNumber.Right, rtContent.Top, rtContent.Width - scwh - NumberBoxWidth, rtContent.Height);
            var rtScroll = new RectangleF(rtBox.Right, rtBox.Top, scwh, rtBox.Height);

            act(rtContent, rtNumber, rtBox, rtScroll);
        }
        #endregion
        #region Get
        #region GetCurPos
        Point? GetCurPos(int x, int y)
        {
            Point? ret = null;

            Areas((rtContent, rtNumber, rtBox, rtScroll) =>
            {
                //if (CollisionTool.Check(rtBox, x, y))
                {
                    double nColumnWidth = (double)(rtContent.Width - rtNumber.Width) / (double)ColumnCount;

                    int px = Convert.ToInt32(Math.Floor((double)(x - rtNumber.Right) / nColumnWidth));
                    int py = Math.Min(Convert.ToInt32(Math.Floor((double)(y + ScrollPosition) / RowHeight)), RowCount - 1);
                    if (px >= 0 && px < ColumnCount && py >= 0 && py < RowCount) ret = new Point(px, py);
                }
            });

            return ret;
        }
        #endregion
        #region GetViewCount
        int GetViewCount()
        {
            int ret = 0;
            Areas((rtContent, rtNumber, rtBox, rtScroll) =>
            {
                ret = Convert.ToInt32(rtBox.Height) / RowHeight;
            });
            return ret;
        }
        #endregion
        #region GetLadderDictionary
        public Dictionary<int, Dictionary<int, LadderItem>> GetLadderDictionary()
        {
            Dictionary<int, Dictionary<int, LadderItem>> ret = new Dictionary<int, Dictionary<int, LadderItem>>();
            foreach (var v in this.Ladders.ToLookup(x => x.Row))
                ret.Add(v.Key, v.ToDictionary(x => x.Col));
            return ret;
        }
        #endregion
        #region ContainsLadder
        public bool ContainsLadder(int row, int col)
        {
            bool ret = false;
            ret = Ladders.Where(x => x.Row == row && x.Col == col).Count() > 0;
            return ret;
        }
        #endregion
        #region GetLadder
        public LadderItem GetLadder(int row, int col)
        {
            LadderItem ret = null;

            var lst = Ladders.Where(x => x.Row == row && x.Col == col).ToList();
            if (lst.Count == 1) ret = lst[0];
            else if (lst.Count > 1)
            {
                ret = lst.FirstOrDefault();
                //throw new Exception("중복");
            }
            return ret;
        }
        #endregion
        #region GetSelectItem
        public List<LadderItem> GetSelectItem()
        {
            List<LadderItem> ret = new List<LadderItem>();
            if (seldown.HasValue && selup.HasValue)
            {
                int minx = Math.Min(seldown.Value.X, selup.Value.X);
                int miny = Math.Min(seldown.Value.Y, selup.Value.Y);
                int maxx = Math.Max(seldown.Value.X, selup.Value.X);
                int maxy = Math.Max(seldown.Value.Y, selup.Value.Y);

                int w = maxx - minx + 1;
                int h = maxy - miny + 1;

                ret.AddRange(Ladders.Where(x => x.Col >= minx && x.Col <= maxx && x.Row >= miny && x.Row <= maxy));
            }
            else if (!seldown.HasValue && !selup.HasValue)
            {
                var v = GetLadder(CurY, CurX);
                if (v != null) ret.Add(v);
            }
            return ret;
        }
        #endregion
        #region GetBin
        string GetBin(int n)
        {
            string r = "", s = "";
            var v = n & 0xFFFF;
            s += (v & 32768) == 32768 ? "1" : "0";
            s += (v & 16384) == 16384 ? "1" : "0";
            s += (v & 8192) == 8192 ? "1" : "0";
            s += (v & 4096) == 4096 ? "1" : "0";
            s += (v & 2048) == 2048 ? "1" : "0";
            s += (v & 1024) == 1024 ? "1" : "0";
            s += (v & 512) == 512 ? "1" : "0";
            s += (v & 256) == 256 ? "1" : "0";
            s += (v & 128) == 128 ? "1" : "0";
            s += (v & 64) == 64 ? "1" : "0";
            s += (v & 32) == 32 ? "1" : "0";
            s += (v & 16) == 16 ? "1" : "0";
            s += (v & 8) == 8 ? "1" : "0";
            s += (v & 4) == 4 ? "1" : "0";
            s += (v & 2) == 2 ? "1" : "0";
            s += (v & 2) == 1 ? "1" : "0";

            bool b = false;
            for (int i = 0; i < 16; i++)
            {
                if (s[i] == '1') { b = true; r += s[i]; }
                else if (s[i] == '0' && b) { r += s[i]; }
            }
            return r == "" ? "0" : r;
        }
        #endregion
        #endregion
        #region Set
        #region SetItem
        #region Fill
        void SetItemFill(int CurY, int CurX, LadderItemType ItemType, bool fillLeft)
        {
            switch (ItemType)
            {
                case LadderItemType.NONE:
                    {
                        var itm = GetLadder(CurY, CurX);
                        if (itm != null) DeleteLadderAction(itm);
                    }
                    break;

                case LadderItemType.IN_A:
                case LadderItemType.IN_B:
                case LadderItemType.LINE_H:
                case LadderItemType.NOT:
                case LadderItemType.OUT_COIL:
                case LadderItemType.OUT_FUNC:
                case LadderItemType.RISING_EDGE:
                case LadderItemType.FALLING_EDGE:
                    {
                        var itm = GetLadder(CurY, CurX);
                        if (itm != null) EditLadderAction(itm, new LadderItem() { Code = itm.Code, Col = itm.Col, Row = itm.Row, ItemType = (fillLeft && itm.ItemType != LadderItemType.NONE ? itm.ItemType : ItemType), VerticalLine = itm.VerticalLine });
                        else AddLadderAction(new LadderItem() { Code = "", Col = CurX, Row = CurY, ItemType = ItemType, VerticalLine = false });
                    }
                    break;

                case LadderItemType.LINE_V:
                    {
                        var itm = GetLadder(CurY, CurX);
                        if (itm != null) EditLadderAction(itm, new LadderItem() { Code = itm.Code, Col = itm.Col, Row = itm.Row, ItemType = itm.ItemType, VerticalLine = !itm.VerticalLine });
                        else AddLadderAction(new LadderItem() { Code = "", Col = CurX, Row = CurY, ItemType = LadderItemType.NONE, VerticalLine = true });
                    }
                    break;
            }
        }
        #endregion
        #region Point
        void SetItemPoint(int CurY, int CurX, LadderItemType ItemType, bool fillLeft)
        {
            switch (ItemType)
            {
                case LadderItemType.NONE:
                    {
                        var itm = GetLadder(CurY, CurX);
                        if (itm != null) DeleteLadderAction(itm);
                    }
                    break;

                case LadderItemType.IN_A:
                case LadderItemType.IN_B:
                case LadderItemType.LINE_H:
                case LadderItemType.NOT:
                case LadderItemType.OUT_COIL:
                case LadderItemType.OUT_FUNC:
                case LadderItemType.RISING_EDGE:
                case LadderItemType.FALLING_EDGE:
                    {
                        var itm = GetLadder(CurY, CurX);

                        if (itm != null)
                        {
                            if ((ItemType == LadderItemType.IN_A && itm.ItemType == LadderItemType.IN_B) || (ItemType == LadderItemType.IN_B && itm.ItemType == LadderItemType.IN_A))
                            {
                                EditLadderAction(itm, new LadderItem() { Code = itm.Code, Col = itm.Col, Row = itm.Row, ItemType = (fillLeft && itm.ItemType != LadderItemType.NONE ? itm.ItemType : ItemType), VerticalLine = itm.VerticalLine });
                            }
                            else
                            {
                                EditLadderAction(itm, new LadderItem() { Code = !itm.Code.StartsWith("'") ? "" : itm.Code, Col = itm.Col, Row = itm.Row, ItemType = (fillLeft && itm.ItemType != LadderItemType.NONE ? itm.ItemType : ItemType), VerticalLine = itm.VerticalLine });
                            }
                        }
                        else AddLadderAction(new LadderItem() { Code = "", Col = CurX, Row = CurY, ItemType = ItemType, VerticalLine = false });
                    }
                    break;

                case LadderItemType.LINE_V:
                    {
                        var itm = GetLadder(CurY, CurX);
                        if (itm != null) EditLadderAction(itm, new LadderItem() { Code = itm.Code, Col = itm.Col, Row = itm.Row, ItemType = itm.ItemType, VerticalLine = !itm.VerticalLine });
                        else AddLadderAction(new LadderItem() { Code = "", Col = CurX, Row = CurY, ItemType = LadderItemType.NONE, VerticalLine = true });
                    }
                    break;
            }
        }
        #endregion
        #endregion
        #region SetCode
        void SetCode(LadderItem v, string code)
        {
            EditLadderAction(v, new LadderItem() { Row = v.Row, Col = v.Col, Code = code, ItemType = v.ItemType, VerticalLine = v.VerticalLine });
        }
        #endregion
        #endregion
        #region Loop
        #region RegionLoop
        void RegionLoop(Point p1, Point p2, Action<int, int> f)
        {
            int minx = Math.Min(seldown.Value.X, selup.Value.X);
            int miny = Math.Min(seldown.Value.Y, selup.Value.Y);
            int maxx = Math.Max(seldown.Value.X, selup.Value.X);
            int maxy = Math.Max(seldown.Value.Y, selup.Value.Y);

            for (int ir = miny; ir <= maxy; ir++)
                for (int ic = minx; ic <= maxx; ic++)
                    f(ir, ic);
        }
        #endregion
        #region HorizonLeftLoop
        void HorizonLeftLoop(int CurY, int CurX, Action<int, int> f)
        {
            int minx = 0;
            var maxx = CurX - 1;

            var r = Ladders.Where(x => (x.Row == CurY && x.ItemType != LadderItemType.NONE) || (x.Row == CurY - 1 && x.VerticalLine));
            if (r.Count() > 0) minx = r.Max(x => x.Col);

            for (int ic = minx; ic <= maxx; ic++) f(CurY, ic);
        }
        #endregion
        #endregion
        #region Action
        public void EditLadderAction(LadderItem olditem, LadderItem newitem)
        {
            actmgr.RecordAction(new LadderEditAction(this, olditem, newitem));
            if (LadderChanged != null) LadderChanged(this, null);
        }
        public void AddLadderAction(LadderItem newitem)
        {
            actmgr.RecordAction(new LadderAddAction(this, newitem));
            if (LadderChanged != null) LadderChanged(this, null);
        }
        public void DeleteLadderAction(LadderItem delitm)
        {
            actmgr.RecordAction(new LadderDeleteAction(this, delitm));
            if (LadderChanged != null) LadderChanged(this, null);
        }
        #endregion
        #region PaintItem
        #region Paint - Item
        public void PaintItem(Graphics g, Color ItemColor, RectangleF rtBox, RectangleF rt, LadderItem itm, Point MousePosition)
        {
            #region Create
            SolidBrush br = new SolidBrush(ItemColor);
            Pen p = new Pen(ItemColor);
            StringFormat strfrm = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
            StringFormat strfrm2 = new StringFormat() { Trimming = StringTrimming.EllipsisCharacter, Alignment = StringAlignment.Center };
            #endregion

            #region Pos Set
            float nw = 18F, nh = 12F;
            float HalfY = rt.Top + ((RowHeight / 3F) * 2F);
            float HalfX = rt.X + (rt.Width / 2F);
            float stx = rt.X + (rt.Width / 2F - nw / 2F);
            float edx = stx + nw;
            float sty = HalfY - (nh / 2F);
            float edy = sty + nh;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            #endregion
            #region Editor
            switch (itm.ItemType)
            {
                case LadderItemType.IN_A:
                    #region IN A
                    {
                        p.Width = 1;
                        g.DrawLine(p, rt.X, HalfY, stx, HalfY);
                        g.DrawLine(p, rt.Right, HalfY, edx, HalfY);

                        p.Width = 2;
                        g.DrawLine(p, stx, sty, stx, edy);
                        g.DrawLine(p, edx, sty, edx, edy);
                    }
                    #endregion
                    break;
                case LadderItemType.IN_B:
                    #region IN B
                    {
                        p.Width = 1;
                        g.DrawLine(p, rt.X, HalfY, stx, HalfY);
                        g.DrawLine(p, rt.Right, HalfY, edx, HalfY);

                        p.Width = 2;
                        g.DrawLine(p, stx, sty, stx, edy);
                        g.DrawLine(p, edx, sty, edx, edy);

                        g.SmoothingMode = SmoothingMode.HighQuality;
                        p.Width = 1;
                        g.DrawLine(p, stx + 5, edy + 0, edx - 5, sty - 0);
                    }
                    #endregion
                    break;
                case LadderItemType.LINE_H:
                    #region LINE_H
                    {
                        p.Width = 1;
                        g.DrawLine(p, rt.X, HalfY, rt.Right, HalfY);
                    }
                    #endregion
                    break;
                case LadderItemType.OUT_COIL:
                    #region OUT_COIL
                    {
                        var isz = 30F;
                        var isx = rt.Width / 2F - isz / 2F;
                        p.Width = 1;
                        g.DrawLine(p, rt.X, HalfY, rt.X + isx, HalfY);

                        g.SmoothingMode = SmoothingMode.HighQuality;
                        p.Width = 2;
                        g.DrawArc(p, new RectangleF(rt.Left + isx, sty, nh, nh), -(90 + 25), -(180 - 50));
                        g.DrawArc(p, new RectangleF(rt.Right - nh - isx, sty, nh, nh), -(90 - 25), (180 - 50));
                    }
                    #endregion
                    break;
                case LadderItemType.OUT_FUNC:
                    #region OUT_FUNC
                    {
                        int gp = 20;
                        var isz = rt.Width - gp;
                        var isx = rt.Width / 2F - isz / 2F;
                        p.Width = 1;
                        g.DrawLine(p, rt.X, HalfY, rt.X + (gp / 2), HalfY);


                        if (itm.Code != null && itm.Code.Split(' ').FirstOrDefault() == "MCS")
                        {
                            p.Width = 2;
                            RectangleF rtmd = new RectangleF(rt.X + isx, sty, isz, nh);
                            g.DrawLine(p, rtmd.Left, rtmd.Top + 1, rtmd.Right, rtmd.Top + 1);
                            g.DrawLine(p, rtmd.Left, rtmd.Top, rtmd.Left, rtmd.Bottom);
                            g.DrawLine(p, rtmd.Right, rtmd.Top, rtmd.Right, rtmd.Bottom);
                        }
                        else if (itm.Code != null && itm.Code.Split(' ').FirstOrDefault() == "MCSCLR")
                        {
                            p.Width = 2;
                            RectangleF rtmd = new RectangleF(rt.X + isx, sty, isz, nh);
                            g.DrawLine(p, rtmd.Left, rtmd.Bottom - 1, rtmd.Right, rtmd.Bottom - 1);
                            g.DrawLine(p, rtmd.Left, rtmd.Top, rtmd.Left, rtmd.Bottom);
                            g.DrawLine(p, rtmd.Right, rtmd.Top, rtmd.Right, rtmd.Bottom);
                        }
                        else
                        {
                            p.Width = 2;
                            RectangleF rtmd = new RectangleF(rt.X + isx, sty, isz, nh);
                            g.DrawLine(p, rtmd.Left, rtmd.Top, rtmd.Left, rtmd.Bottom);
                            g.DrawLine(p, rtmd.Right, rtmd.Top, rtmd.Right, rtmd.Bottom);

                            g.DrawLine(p, rtmd.Left, rtmd.Top + 1, rtmd.Left + 5, rtmd.Top + 1);
                            g.DrawLine(p, rtmd.Right, rtmd.Top + 1, rtmd.Right - 5, rtmd.Top + 1);
                            g.DrawLine(p, rtmd.Left, rtmd.Bottom - 1, rtmd.Left + 5, rtmd.Bottom - 1);
                            g.DrawLine(p, rtmd.Right, rtmd.Bottom - 1, rtmd.Right - 5, rtmd.Bottom - 1);
                        }
                    }
                    #endregion
                    break;
                case LadderItemType.RISING_EDGE:
                    #region RISING EDGE
                    {
                        p.Width = 1;
                        g.DrawLine(p, rt.X, HalfY, rt.Right, HalfY);
                        p.Width = 2;
                        g.DrawLine(p, HalfX, sty, HalfX, edy);
                        g.DrawLine(p, HalfX - 1, sty, HalfX + 5, sty);
                        g.DrawLine(p, HalfX + 1, edy, HalfX - 5, edy);
                    }
                    #endregion
                    break;
                case LadderItemType.FALLING_EDGE:
                    #region FALLING EDGE
                    {
                        p.Width = 1;
                        g.DrawLine(p, rt.X, HalfY, rt.Right, HalfY);
                        p.Width = 2;
                        g.DrawLine(p, HalfX, sty, HalfX, edy);
                        g.DrawLine(p, HalfX + 1, sty, HalfX - 5, sty);
                        g.DrawLine(p, HalfX - 1, edy, HalfX + 5, edy);
                    }
                    #endregion
                    break;
                case LadderItemType.NOT:
                    #region NOT
                    {
                        p.Width = 1;
                        g.DrawLine(p, rt.X, HalfY, stx, HalfY);
                        g.DrawLine(p, rt.Right, HalfY, edx, HalfY);

                        p.Width = 2;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawLine(p, stx + 5, edy + 0, edx - 5, sty - 0);
                    }
                    #endregion
                    break;
            }

            if (itm.VerticalLine)
            {
                #region LINE_V
                {
                    p.Width = 1;
                    g.DrawLine(p, rt.Left, HalfY, rt.Left, HalfY + rt.Height);
                }
                #endregion
            }
            #endregion
            #region Message
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (itm.Code != null && itm.Code != "")
            {
                string str = itm.ItemType == LadderItemType.OUT_FUNC && itm.Code.StartsWith("{") ? "{ ... }" : itm.Code;

                SizeF sz = g.MeasureString(str, Font);
                var BtmY = Convert.ToSingle(sty - 5);
                var nx = Convert.ToSingle(HalfX - (sz.Width / 2));
                if (str.Length >= 2 && str.Substring(0, 1) == "'" && str.Substring(0, 2) != "''") nx = Convert.ToInt32(rt.X + (rt.Width / 8));
                var ny = Convert.ToSingle(BtmY - sz.Height);
                int LineWidth = 41;
                if (nx < LineWidth) nx = LineWidth;
                nx = Math.Max(nx, rt.Left);

                br.Color = ItemColor;
                if (str.Length > 0 && str.StartsWith("'") && ItemColor != Color.Magenta) br.Color = Color.Lime;
                if (str.Length > 0 && str.StartsWith("#") && itm.Col == 0 && ItemColor != Color.Magenta) br.Color = Color.Orange;

                if (sz.Width > rt.Width && CollisionTool.Check(rt, MousePosition))
                {
                    var old = br.Color;

                    var rtb = MathTool.MakeRectangle(new RectangleF(rt.X, ny, rt.Width, 14), new SizeF((sz.Width + 10), 24));
                    var rtm = MathTool.MakeRectangle(new RectangleF(rt.X, ny, rt.Width, 14), new SizeF((sz.Width + 10), sz.Height + 0));
                    if (rtb.Right > this.Width) rtb.X = this.Width - rtb.Width - 1;

                    p.Width = 1;
                    br.Color = Color.FromArgb(30, 30, 30); g.FillRoundRectangle(br, Util.INT(rtb), 5);
                    p.Color = Color.FromArgb(90, 90, 90); g.DrawRoundRectangle(p, Util.INT(rtb), 5);

                    br.Color = old;
                    g.DrawString(itm.Code, Font, br, rtb, strfrm);
                }
                else
                {
                    var rtm = MathTool.MakeRectangle(new RectangleF(rt.X, ny, rt.Width, 14), new SizeF(rt.Width, sz.Height + 0));
                    g.DrawString(str, Font, br, rtm, strfrm2);
                }
            }
            #endregion
            #region Alias
            if (Program.MainForm.CurrentDocument != null)
            {
                using (Font ft = new Font(Font.FontFamily, AliasFontSize, FontStyle.Regular))
                {
                    var v = Program.MainForm.CurrentDocument.Symbols.Where(x => x.Address == itm.Code).FirstOrDefault();
                    if (v != null)
                    {
                        #region SymbolName
                        {
                            var sz2 = g.MeasureString(v.SymbolName, ft);
                            int nx2 = Convert.ToInt32(HalfX - (sz2.Width / 2));
                            br.Color = ItemColor == Color.Magenta ? ItemColor : Color.Aqua;
                            g.DrawString(v.SymbolName, ft, br, edx + (itm.ItemType == LadderItemType.IN_A || itm.ItemType == LadderItemType.IN_B ? 5 : 10), HalfY + 2);
                        }
                        #endregion
                    }
                    else
                    {
                        var v2 = Program.MainForm.CurrentDocument.Symbols.Where(x => x.SymbolName == itm.Code).FirstOrDefault();
                        if (v2 != null)
                        {
                            #region Address
                            {
                                var sz2 = g.MeasureString(v2.SymbolName, ft);
                                int nx2 = Convert.ToInt32(HalfX - (sz2.Width / 2));
                                br.Color = ItemColor == Color.Magenta ? ItemColor : Color.Aqua;
                                g.DrawString(v2.Address, ft, br, edx + (itm.ItemType == LadderItemType.IN_A || itm.ItemType == LadderItemType.IN_B ? 5 : 10), HalfY + 2);
                            }
                            #endregion
                        }
                    }
                }
            }
            #endregion

            #region Dispose
            p.Dispose();
            br.Dispose();
            strfrm.Dispose();
            strfrm2.Dispose();
            #endregion
        }
        #endregion
        #region Paint - Debug
        public void PaintDebug(Graphics g, RectangleF rt, LadderItem itm)
        {
            #region Create
            SolidBrush br = new SolidBrush(Color.White);
            Pen p = new Pen(Color.White);
            StringFormat strfrm = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
            StringFormat strfrm2 = new StringFormat() { Trimming = StringTrimming.EllipsisCharacter };
            #endregion

            #region Pos Set
            float nw = 18F, nh = 12F;
            float HalfY = rt.Top + ((RowHeight / 3F) * 2F);
            float HalfX = rt.X + (rt.Width / 2F);
            float stx = rt.X + (rt.Width / 2F - nw / 2F);
            float edx = stx + nw;
            float sty = HalfY - (nh / 2F);
            float edy = sty + nh;

            g.SmoothingMode = SmoothingMode.HighSpeed;
            #endregion
            #region Editor
            switch (itm.ItemType)
            {
                case LadderItemType.IN_A:
                    #region IN A
                    {
                        p.Width = 1;
                        p.Color = itm.PrevMonitorV ? Color.Red : Color.White;
                        g.DrawLine(p, rt.X, HalfY, stx, HalfY);
                        p.Color = (itm.MonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.Right, HalfY, edx, HalfY);

                        p.Width = 2;
                        g.DrawLine(p, stx, sty, stx, edy);
                        g.DrawLine(p, edx, sty, edx, edy);

                        if (itm.Monitor)
                        {
                            var old = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.HighSpeed;
                            br.Color = Color.Lime;
                            g.FillRectangle(br, new RectangleF(stx + 4, sty + 2, (edx - 5) - (stx + 4), (edy - 2) - (sty + 2)));
                            g.SmoothingMode = old;
                        }
                    }
                    #endregion
                    break;
                case LadderItemType.IN_B:
                    #region IN B
                    {
                        p.Width = 1;
                        p.Color = itm.PrevMonitorV ? Color.Red : Color.White;
                        g.DrawLine(p, rt.X, HalfY, stx, HalfY);
                        p.Color = (itm.MonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.Right, HalfY, edx, HalfY);

                        p.Width = 2;
                        g.DrawLine(p, stx, sty, stx, edy);
                        g.DrawLine(p, edx, sty, edx, edy);

                        if (!itm.Monitor)
                        {
                            var old = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.HighSpeed;
                            br.Color = Color.Lime;
                            g.FillRectangle(br, new RectangleF(stx + 4, sty + 2, (edx - 5) - (stx + 4), (edy - 2) - (sty + 2)));
                            g.SmoothingMode = old;
                        }

                        g.SmoothingMode = SmoothingMode.HighQuality;
                        p.Width = 1;
                        g.DrawLine(p, stx + 5, edy + 0, edx - 5, sty - 0);
                    }
                    #endregion
                    break;
                case LadderItemType.LINE_H:
                    #region LINE_H
                    {
                        p.Width = 1;
                        p.Color = (itm.MonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.X, HalfY, rt.Right, HalfY);
                    }
                    #endregion
                    break;
                case LadderItemType.OUT_COIL:
                    #region OUT_COIL
                    {
                        float isz = 30;
                        float isx = rt.Width / 2F - isz / 2F;
                        p.Width = 1;
                        p.Color = (itm.PrevMonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.X, HalfY, rt.X + isx, HalfY);

                        g.SmoothingMode = SmoothingMode.HighQuality;
                        p.Width = 2;
                        g.DrawArc(p, new RectangleF(rt.Left + isx, sty, nh, nh), -(90 + 25), -(180 - 50));
                        g.DrawArc(p, new RectangleF(rt.Right - nh - isx, sty, nh, nh), -(90 - 25), (180 - 50));

                        if (itm.Monitor)
                        {
                            var old = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            br.Color = Color.Lime;
                            g.FillEllipse(br, MathTool.MakeRectangle(new PointF(HalfX, HalfY), 10));
                            g.SmoothingMode = old;
                        }
                    }
                    #endregion
                    break;
                case LadderItemType.OUT_FUNC:
                    #region OUT_FUNC
                    {
                        int gp = 20;
                        var isz = rt.Width - gp;
                        var isx = rt.Width / 2F - isz / 2F;
                        p.Width = 1;
                        p.Color = (itm.PrevMonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.X, HalfY, rt.X + (gp / 2), HalfY);


                        if (itm.Code != null && itm.Code.Split(' ').FirstOrDefault() == "MCS")
                        {
                            p.Width = 2;
                            var rtmd = new RectangleF(rt.X + isx, sty, isz, nh);
                            g.DrawLine(p, rtmd.Left, rtmd.Top + 1, rtmd.Right, rtmd.Top + 1);
                            g.DrawLine(p, rtmd.Left, rtmd.Top, rtmd.Left, rtmd.Bottom);
                            g.DrawLine(p, rtmd.Right, rtmd.Top, rtmd.Right, rtmd.Bottom);
                        }
                        else if (itm.Code != null && itm.Code.Split(' ').FirstOrDefault() == "MCSCLR")
                        {
                            p.Width = 2;
                            var rtmd = new RectangleF(rt.X + isx, sty, isz, nh);
                            g.DrawLine(p, rtmd.Left, rtmd.Bottom - 1, rtmd.Right, rtmd.Bottom - 1);
                            g.DrawLine(p, rtmd.Left, rtmd.Top, rtmd.Left, rtmd.Bottom);
                            g.DrawLine(p, rtmd.Right, rtmd.Top, rtmd.Right, rtmd.Bottom);
                        }
                        else
                        {
                            var rtmd = new RectangleF(rt.X + isx, sty, isz, nh);

                            if (itm.Monitor)
                            {
                                var old = g.SmoothingMode;
                                g.SmoothingMode = SmoothingMode.HighSpeed;

                                var rtmd2txt = new RectangleF(rtmd.X + 10, rtmd.Y + 1, rtmd.Width - 21, rtmd.Height + 2);
                                var rtmd2 = new RectangleF(rtmd.X + 10, rtmd.Y - 2, rtmd.Width - 21, rtmd.Height + 2);
                                br.Color = Color.FromArgb(50, Color.Lime);
                                g.FillRectangle(br, rtmd2);

                                p.Color = Color.Lime; p.Width = 1;
                                g.DrawRectangle(p, rtmd2);

                                var cd = itm.Code.ToUpper();
                                if (cd.StartsWith("TON") || cd.StartsWith("TAON") || cd.StartsWith("TOFF") || cd.StartsWith("TAOFF") || cd.StartsWith("TMON") || cd.StartsWith("TAMON"))
                                {
                                    var str = "";

                                    switch (LadderDisplayType)
                                    {
                                        case LadderDisplayKinds.HEX: str = "0x" + itm.Timer.ToString("X4"); break;
                                        case LadderDisplayKinds.DEC: str = itm.Timer.ToString(); break;
                                        case LadderDisplayKinds.BIN: str = GetBin(itm.Timer); break;
                                    }
                                    br.Color = Color.White;
                                    g.DrawString(str, Font, br, rtmd2txt, strfrm);

                                }

                                g.SmoothingMode = old;
                            }
                            p.Color = itm.Monitor ? Color.Red : Color.White;
                            p.Width = 2;

                            g.DrawLine(p, rtmd.Left, rtmd.Top, rtmd.Left, rtmd.Bottom);
                            g.DrawLine(p, rtmd.Right, rtmd.Top, rtmd.Right, rtmd.Bottom);

                            g.DrawLine(p, rtmd.Left, rtmd.Top + 1, rtmd.Left + 5, rtmd.Top + 1);
                            g.DrawLine(p, rtmd.Right, rtmd.Top + 1, rtmd.Right - 5, rtmd.Top + 1);
                            g.DrawLine(p, rtmd.Left, rtmd.Bottom - 1, rtmd.Left + 5, rtmd.Bottom - 1);
                            g.DrawLine(p, rtmd.Right, rtmd.Bottom - 1, rtmd.Right - 5, rtmd.Bottom - 1);
                        }
                    }
                    #endregion
                    break;
                case LadderItemType.RISING_EDGE:
                    #region RISING EDGE
                    {
                        p.Width = 1;
                        p.Color = (itm.PrevMonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.X, HalfY, HalfX, HalfY);
                        p.Color = (itm.MonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, HalfX, HalfY, rt.Right, HalfY);
                        p.Width = 2;
                        g.DrawLine(p, HalfX, sty, HalfX, edy);
                        g.DrawLine(p, HalfX - 1, sty, HalfX + 5, sty);
                        g.DrawLine(p, HalfX + 1, edy, HalfX - 5, edy);
                    }
                    #endregion
                    break;
                case LadderItemType.FALLING_EDGE:
                    #region FALLING EDGE
                    {
                        p.Width = 1;
                        p.Color = (itm.PrevMonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.X, HalfY, HalfX, HalfY);
                        p.Color = (itm.MonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, HalfX, HalfY, rt.Right, HalfY);
                        p.Width = 2;
                        g.DrawLine(p, HalfX, sty, HalfX, edy);
                        g.DrawLine(p, HalfX + 1, sty, HalfX - 5, sty);
                        g.DrawLine(p, HalfX - 1, edy, HalfX + 5, edy);
                    }
                    #endregion
                    break;
                case LadderItemType.NOT:
                    #region NOT
                    {
                        p.Width = 1;
                        p.Color = (itm.PrevMonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.X, HalfY, stx, HalfY);
                        p.Color = (itm.MonitorV) ? Color.Red : Color.White;
                        g.DrawLine(p, rt.Right, HalfY, edx, HalfY);

                        p.Width = 2;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawLine(p, stx + 5, edy + 0, edx - 5, sty - 0);
                    }
                    #endregion
                    break;
            }

            if (itm.VerticalLine)
            {
                #region LINE_V
                {
                    p.Width = 1;
                    p.Color = (itm.VerticalMonitorV) ? Color.Red : Color.White;
                    g.DrawLine(p, rt.Left, HalfY, rt.Left, HalfY + rt.Height);
                }
                #endregion
            }
            #endregion
            #region Message
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (itm.Code != null && itm.Code != "")
            {
                string str = itm.ItemType == LadderItemType.OUT_FUNC && itm.Code.StartsWith("{") ? "{ ... }" : itm.Code;

                SizeF sz = g.MeasureString(str, Font);
                float BtmY = Convert.ToInt32(sty - 5);
                float nx = Convert.ToInt32(HalfX - (sz.Width / 2));
                if (str.Length >= 2 && str.Substring(0, 1) == "'" && str.Substring(0, 2) != "''") nx = Convert.ToInt32(rt.X + (rt.Width / 8));
                float ny = Convert.ToInt32(BtmY - sz.Height);
                float LineWidth = 41;
                if (nx < LineWidth) nx = LineWidth;
                nx = Math.Max(nx, rt.Left);

                br.Color = Color.White;
                if (str.Length > 0 && str.StartsWith("'")) br.Color = Color.Lime;
                if (str.Length > 0 && str.StartsWith("#") && itm.Col == 0) br.Color = Color.Orange;

                if (sz.Width > rt.Width && CollisionTool.Check(rt, MousePosition))
                {
                    var old = br.Color;

                    var rtb = MathTool.MakeRectangle(new RectangleF(rt.X, ny, rt.Width, 14), new SizeF(Convert.ToInt32(sz.Width + 10), 24));
                    var rtm = MathTool.MakeRectangle(new RectangleF(rt.X, ny, rt.Width, 14), new SizeF(Convert.ToInt32(sz.Width + 10), sz.Height + 0));
                    if (rtb.Right > this.Width) rtb.X = this.Width - rtb.Width - 1;

                    p.Width = 1;
                    br.Color = Color.FromArgb(30, 30, 30); g.FillRoundRectangle(br, rtb, 5);
                    p.Color = Color.FromArgb(90, 90, 90); g.DrawRoundRectangle(p, rtb, 5);

                    br.Color = old;
                    g.DrawString(itm.Code, Font, br, rtm, strfrm);
                }
                else
                {
                    var rtm = MathTool.MakeRectangle(new RectangleF(rt.X, ny, rt.Width, 14), new SizeF(rt.Width, sz.Height + 0));
                    g.DrawString(str, Font, br, rtm, strfrm2);
                }
            }
            #endregion
            #region Alias
            if (Program.MainForm.CurrentDocument != null)
            {
                using (Font ft = new Font(Font.FontFamily, AliasFontSize, FontStyle.Regular))
                {
                    var v = Program.MainForm.CurrentDocument.Symbols.Where(x => x.Address == itm.Code).FirstOrDefault();
                    if (v != null)
                    {
                        #region SymbolName
                        {
                            var sz2 = g.MeasureString(v.SymbolName, ft);
                            int nx2 = Convert.ToInt32(HalfX - (sz2.Width / 2));
                            br.Color = Color.Aqua;
                            g.DrawString(v.SymbolName, ft, br, edx + (itm.ItemType == LadderItemType.IN_A || itm.ItemType == LadderItemType.IN_B ? 5 : 10), HalfY + 2);
                        }
                        #endregion
                    }
                    else
                    {
                        var v2 = Program.MainForm.CurrentDocument.Symbols.Where(x => x.SymbolName == itm.Code).FirstOrDefault();
                        if (v2 != null)
                        {
                            #region Address
                            {
                                var sz2 = g.MeasureString(v2.SymbolName, ft);
                                int nx2 = Convert.ToInt32(HalfX - (sz2.Width / 2));
                                br.Color = Color.Aqua;
                                g.DrawString(v2.Address, ft, br, edx + (itm.ItemType == LadderItemType.IN_A || itm.ItemType == LadderItemType.IN_B ? 5 : 10), HalfY + 2);
                            }
                            #endregion
                        }
                    }
                }
            }
            #endregion
            #region Watch
            if (itm.Code != null && itm.Code.StartsWith("''"))
            {
                var str = "";
                var doc = Program.MainForm.CurrentDocument;
                var addr = doc.GetSymbolAddress(itm.Code.Substring(2));
                if (doc.ValidAddress(addr))
                {
                    if (addr.StartsWith("R"))
                    {
                        str = itm.WatchF.ToString();
                    }
                    else if (addr.StartsWith("P") || addr.StartsWith("M"))
                    {
                        str = itm.Monitor ? "ON" : "OFF";
                    }
                    else
                    {
                        switch (LadderDisplayType)
                        {
                            case LadderDisplayKinds.HEX: str = "0x" + itm.Watch.ToString("X4"); break;
                            case LadderDisplayKinds.DEC: str = itm.Watch.ToString(); break;
                            case LadderDisplayKinds.BIN: str = GetBin(itm.Watch); break;
                        }
                    }
                }

                var rtwatch = new RectangleF(rt.X + 10, sty, rt.Width - 20, 18);
                var rtwatchtxt = new RectangleF(rt.X + 10, sty + 3, rt.Width - 20, 18);

                p.Color = Color.Lime; p.Width = 1;
                g.DrawRectangle(p, rtwatch);

                br.Color = Color.FromArgb(50, Color.Lime);
                g.FillRectangle(br, rtwatch);

                br.Color = Color.White;
                g.DrawString(str, Font, br, rtwatchtxt, strfrm);

            }
            #endregion

            #region Dispose
            p.Dispose();
            br.Dispose();
            strfrm.Dispose();
            strfrm2.Dispose();
            #endregion
        }
        #endregion
        #endregion
        #region Move
        #region Normal
        void MoveLeft() { CurX--; }
        void MoveRight() { CurX++; }
        void MoveUp() { CurY--; }
        void MoveDown() { CurY++; }
        void MovePageUp() { CurY -= GetViewCount(); }
        void MovePageDown() { CurY += GetViewCount(); }
        void MoveHome() { CurX = 0; }
        void MoveEnd() { CurX = ColumnCount - 1; }
        #endregion
        #region Shift
        void MoveShiftLeft()
        {
            #region Shift + Left
            if (seldown.HasValue)
            {
                int nCurX = 0, nCurY = 0;
                if (!selmove.HasValue) { nCurX = seldown.Value.X; nCurY = seldown.Value.Y; }
                else { nCurX = selmove.Value.X; nCurY = selmove.Value.Y; }
                nCurX = (int)MathTool.Constrain(nCurX - 1, 0, ColumnCount - 1);
                selmove = new Point(nCurX, nCurY);
                Invalidate();
            }
            else { seldown = new Point(CurX, CurY); selmove = new Point((int)MathTool.Constrain(CurX - 1, 0, ColumnCount - 1), CurY); selup = null; Invalidate(); }
            #endregion
            if (selmove.HasValue) { CurX = selmove.Value.X; CurY = selmove.Value.Y; }
        }
        void MoveShiftRight()
        {
            #region Shift + Right
            if (seldown.HasValue)
            {
                int nCurX = 0, nCurY = 0;
                if (!selmove.HasValue) { nCurX = seldown.Value.X; nCurY = seldown.Value.Y; }
                else { nCurX = selmove.Value.X; nCurY = selmove.Value.Y; }
                nCurX = (int)MathTool.Constrain(nCurX + 1, 0, ColumnCount - 1);
                selmove = new Point(nCurX, nCurY);
                Invalidate();
            }
            else { seldown = new Point(CurX, CurY); selmove = new Point((int)MathTool.Constrain(CurX + 1, 0, ColumnCount - 1), CurY); selup = null; Invalidate(); }
            #endregion
            if (selmove.HasValue) { CurX = selmove.Value.X; CurY = selmove.Value.Y; }
        }
        void MoveShiftUp()
        {
            #region Shift + Up
            if (seldown.HasValue)
            {
                int nCurX = 0, nCurY = 0;
                if (!selmove.HasValue) { nCurX = seldown.Value.X; nCurY = seldown.Value.Y; }
                else { nCurX = selmove.Value.X; nCurY = selmove.Value.Y; }
                nCurY = (int)MathTool.Constrain(nCurY - 1, 0, RowCount - 1);

                selmove = new Point(nCurX, nCurY);
                Invalidate();
            }
            else { seldown = new Point(CurX, CurY); selmove = new Point(CurX, (int)MathTool.Constrain(CurY - 1, 0, RowCount - 1)); selup = null; Invalidate(); }
            #endregion
            if (selmove.HasValue) { CurX = selmove.Value.X; CurY = selmove.Value.Y; }
        }
        void MoveShiftDown()
        {
            #region Shift + Down
            if (seldown.HasValue)
            {
                int nCurX = 0, nCurY = 0;
                if (!selmove.HasValue) { nCurX = seldown.Value.X; nCurY = seldown.Value.Y; }
                else { nCurX = selmove.Value.X; nCurY = selmove.Value.Y; }
                nCurY = (int)MathTool.Constrain(nCurY + 1, 0, RowCount - 1);
                selmove = new Point(nCurX, nCurY);
                Invalidate();
            }
            else { seldown = new Point(CurX, CurY); selmove = new Point(CurX, (int)MathTool.Constrain(CurY + 1, 0, RowCount - 1)); selup = null; Invalidate(); }
            #endregion
            if (selmove.HasValue) { CurX = selmove.Value.X; CurY = selmove.Value.Y; }
        }
        void MoveShiftPageUp()
        {
            #region Shift + PageUp
            if (seldown.HasValue)
            {
                int nCurX = 0, nCurY = 0;
                if (!selmove.HasValue) { nCurX = seldown.Value.X; nCurY = seldown.Value.Y; }
                else { nCurX = selmove.Value.X; nCurY = selmove.Value.Y; }
                nCurY = (int)MathTool.Constrain(nCurY - GetViewCount(), 0, RowCount - 1);
                selmove = new Point(nCurX, nCurY);
                Invalidate();
            }
            else { seldown = new Point(CurX, CurY); selmove = new Point(CurX, (int)MathTool.Constrain(CurY - GetViewCount(), 0, RowCount - 1)); selup = null; Invalidate(); }
            #endregion
            if (selmove.HasValue) { CurX = selmove.Value.X; CurY = selmove.Value.Y; }
        }
        void MoveShiftPageDown()
        {
            #region Shift + PageDown
            if (seldown.HasValue)
            {
                int nCurX = 0, nCurY = 0;
                if (!selmove.HasValue) { nCurX = seldown.Value.X; nCurY = seldown.Value.Y; }
                else { nCurX = selmove.Value.X; nCurY = selmove.Value.Y; }
                nCurY = (int)MathTool.Constrain(nCurY + GetViewCount(), 0, RowCount - 1);
                selmove = new Point(nCurX, nCurY);
                Invalidate();
            }
            else { seldown = new Point(CurX, CurY); selmove = new Point(CurX, (int)MathTool.Constrain(CurY + GetViewCount(), 0, RowCount - 1)); selup = null; Invalidate(); }
            #endregion
            if (selmove.HasValue) { CurX = selmove.Value.X; CurY = selmove.Value.Y; }
        }
        void MoveShiftHome()
        {
            #region Shift + Home
            if (seldown.HasValue)
            {
                int nCurX = 0, nCurY = 0;
                if (!selmove.HasValue) { nCurX = seldown.Value.X; nCurY = seldown.Value.Y; }
                else { nCurX = selmove.Value.X; nCurY = selmove.Value.Y; }
                nCurX = (int)MathTool.Constrain(0, 0, ColumnCount - 1);
                selmove = new Point(nCurX, nCurY);
                Invalidate();
            }
            else { seldown = new Point(CurX, CurY); selmove = new Point(0, CurY); selup = null; Invalidate(); }
            #endregion
            if (selmove.HasValue) { CurX = selmove.Value.X; CurY = selmove.Value.Y; }
        }
        void MoveShiftEnd()
        {
            #region Shift + End
            if (seldown.HasValue)
            {
                int nCurX = 0, nCurY = 0;
                if (!selmove.HasValue) { nCurX = seldown.Value.X; nCurY = seldown.Value.Y; }
                else { nCurX = selmove.Value.X; nCurY = selmove.Value.Y; }
                nCurX = (int)MathTool.Constrain(ColumnCount - 1, 0, ColumnCount - 1);
                selmove = new Point(nCurX, nCurY);
                Invalidate();
            }
            else { seldown = new Point(CurX, CurY); selmove = new Point(ColumnCount - 1, CurY); selup = null; Invalidate(); }
            #endregion
            if (selmove.HasValue) { CurX = selmove.Value.X; CurY = selmove.Value.Y; }
        }
        #endregion
        #region Control
        void MoveControlLeft() { CurX = 0; }
        void MoveControlRight() { if (Ladders.Where(x => x.Row == CurY).Count() > 0) CurX = Ladders.Where(x => x.Row == CurY).Max(x => x.Col); else CurX = ColumnCount - 1; }
        void MoveControlUp() { CurY = 0; }
        void MoveControlDown() { if (Ladders.Count > 0) CurY = Ladders.Max(x => x.Row); else CurY = RowCount - 1; }
        #endregion
        #endregion
        #region Item
        #region NONE
        public void ItemNONE()
        {
            if (!Debug && Buffer.Count == 0)
            {
                if (seldown.HasValue && selup.HasValue)
                {
                    using (var tr = actmgr.CreateTransaction())
                    {
                        RegionLoop(seldown.Value, selup.Value, (row, col) => { SetItemFill(row, col, LadderItemType.NONE, false); });
                    }

                    bCutBuffer = false;
                    seldown = selmove = selup = null;
                    Invalidate();
                }
                else if (!seldown.HasValue && !selup.HasValue)
                {
                    SetItemPoint(CurY, CurX, LadderItemType.NONE, false);
                    CurX++;
                }
            }
        }
        #endregion
        #region IN_A
        public void ItemIN_A()
        {
            if (!Debug && Buffer.Count == 0)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    HorizonLeftLoop(CurY, CurX, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                    SetItemPoint(CurY, CurX, LadderItemType.IN_A, false);
                }
                CurX++;
            }
        }
        #endregion
        #region IN_B
        public void ItemIN_B()
        {
            if (!Debug && Buffer.Count == 0)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    HorizonLeftLoop(CurY, CurX, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                    SetItemPoint(CurY, CurX, LadderItemType.IN_B, false);
                }
                CurX++;
            }
        }
        #endregion
        #region LINE_H
        public void ItemLINE_H()
        {
            if (!Debug && Buffer.Count == 0)
            {
                if (seldown.HasValue && selup.HasValue)
                {
                    using (var tr = actmgr.CreateTransaction())
                    {
                        RegionLoop(seldown.Value, selup.Value, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                    }

                    bCutBuffer = false;
                    seldown = selmove = selup = null;
                    Invalidate();
                }
                else if (!seldown.HasValue && !selup.HasValue)
                {
                    using (var tr = actmgr.CreateTransaction())
                    {
                        HorizonLeftLoop(CurY, CurX, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                        SetItemPoint(CurY, CurX, LadderItemType.LINE_H, false);
                    }
                    CurX++;
                }
            }
        }
        #endregion
        #region LINE_V
        public void ItemLINE_V()
        {
            if (!Debug && Buffer.Count == 0)
            {
                if (seldown.HasValue && selup.HasValue)
                {
                    using (var tr = actmgr.CreateTransaction())
                    {
                        RegionLoop(seldown.Value, selup.Value, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_V, true); });
                    }

                    bCutBuffer = false;
                    seldown = selmove = selup = null;
                    Invalidate();
                }
                else if (!seldown.HasValue && !selup.HasValue)
                {
                    SetItemPoint(CurY, CurX, LadderItemType.LINE_V, false);
                    CurY++;
                }
            }
        }
        #endregion
        #region OUT_COIL
        public void ItemOUT_COIL()
        {
            if (!Debug && Buffer.Count == 0)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    HorizonLeftLoop(CurY, CurX, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                    SetItemPoint(CurY, CurX, LadderItemType.OUT_COIL, false);
                    Invalidate();
                }
            }
        }
        #endregion
        #region OUT_FUNC
        public void ItemOUT_FUNC()
        {
            if (!Debug && Buffer.Count == 0)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    HorizonLeftLoop(CurY, CurX, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                    SetItemPoint(CurY, CurX, LadderItemType.OUT_FUNC, false);
                    Invalidate();
                }
            }
        }
        #endregion
        #region NOT
        public void ItemNOT()
        {
            if (!Debug && Buffer.Count == 0)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    HorizonLeftLoop(CurY, CurX, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                    SetItemPoint(CurY, CurX, LadderItemType.NOT, false);
                    Invalidate();
                }
            }
        }
        #endregion
        #region RISING_EDGE
        public void ItemRISING_EDGE()
        {
            if (!Debug && Buffer.Count == 0)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    HorizonLeftLoop(CurY, CurX, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                    SetItemPoint(CurY, CurX, LadderItemType.RISING_EDGE, false);
                    Invalidate();
                }
            }
        }
        #endregion
        #region FALLING_EDGE
        public void ItemFALLING_EDGE()
        {
            if (!Debug && Buffer.Count == 0)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    HorizonLeftLoop(CurY, CurX, (row, col) => { SetItemFill(row, col, LadderItemType.LINE_H, true); });
                    SetItemPoint(CurY, CurX, LadderItemType.FALLING_EDGE, false);
                    Invalidate();
                }
            }
        }
        #endregion
        #endregion
        #region Line
        #region LineInsert
        public void LineInsert()
        {
            if (!Debug)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    foreach (var v in Ladders.Where(x => x.Row >= CurY)) EditLadderAction(v, new LadderItem() { Row = v.Row + 1, Col = v.Col, Code = v.Code, ItemType = v.ItemType, VerticalLine = v.VerticalLine });
                }
                Invalidate();
            }
        }
        #endregion
        #region LineDelete
        public void LineDelete()
        {
            if (!Debug)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    foreach (var v in Ladders.Where(x => x.Row == CurY)) DeleteLadderAction(v);
                    foreach (var v in Ladders.Where(x => x.Row > CurY)) EditLadderAction(v, new LadderItem() { Row = v.Row - 1, Col = v.Col, Code = v.Code, ItemType = v.ItemType, VerticalLine = v.VerticalLine });
                }
                Invalidate();
            }
        }
        #endregion
        #endregion
        #region Cell
        #region CellInsert
        public void CellInsert()
        {
            if (!Debug)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    int row = CurY;
                    int col = CurX;
                    var vl = Ladders.Where(x => x.Row == row && x.Col >= col);
                    if (vl.Count() > 0 && vl.Max(x => x.Col) + 1 < ColumnCount)
                        foreach (var v in vl) EditLadderAction(v, new LadderItem() { Row = v.Row, Col = v.Col + 1, Code = v.Code, ItemType = v.ItemType, VerticalLine = v.VerticalLine });
                }
                Invalidate();
            }
        }
        #endregion
        #region CellDelete
        public void CellDelete()
        {
            if (!Debug)
            {
                using (var tr = GuiLabs.Undo.Transaction.Create(actmgr))
                {
                    if (ContainsLadder(CurY, CurX)) DeleteLadderAction(GetLadder(CurY, CurX));
                    else
                    {
                        foreach (var v in Ladders.Where(x => x.Row == CurY && x.Col > CurX))
                            EditLadderAction(v, new LadderItem() { Row = v.Row, Col = v.Col - 1, Code = v.Code, ItemType = v.ItemType, VerticalLine = v.VerticalLine });
                    }
                }
                Invalidate();
            }
        }
        #endregion
        #endregion
        #region Reset
        public void Reset()
        {
            actmgr.Clear();
            Invalidate();
        }
        #endregion
        #region Edit
        #region Undo
        public void Undo()
        {
            if (!Debug)
            {
                if (actmgr.CanUndo) { actmgr.Undo(); Invalidate(); if (LadderChanged != null) LadderChanged(this, null); }
            }
        }

        void UndoForce()
        {
            if (actmgr.CanUndo) { actmgr.Undo(); Invalidate(); if (LadderChanged != null) LadderChanged(this, null); }
        }
        #endregion
        #region Redo
        public void Redo()
        {
            if (!Debug)
            {
                if (actmgr.CanRedo) { actmgr.Redo(); Invalidate(); if (LadderChanged != null) LadderChanged(this, null); }
            }
        }
        #endregion
        #region Copy
        public void Copy()
        {
            if (!Debug)
            {
                Buffer.Clear();
                var v = GetSelectItem();
                var itm = v.OrderBy(x => x.Col).ThenBy(x => x.Row).FirstOrDefault();
                if (itm != null) { CurX = itm.Col; CurY = itm.Row; }
                Buffer.AddRange(v.Select(x => x.Clone()));
                bCutBuffer = false;
                Invalidate();

                if (LadderChanged != null) LadderChanged(this, null);
            }
        }
        #endregion
        #region Cut
        public void Cut()
        {
            if (!Debug)
            {
                Buffer.Clear();
                var v = GetSelectItem();

                using (var tr = actmgr.CreateTransaction())
                {
                    foreach (var _v in v) DeleteLadderAction(_v);
                }

                var itm = v.OrderBy(x => x.Col).ThenBy(x => x.Row).FirstOrDefault();
                if (itm != null) { CurX = itm.Col; CurY = itm.Row; }
                Buffer.AddRange(v.Select(x => x.Clone()));
                bCutBuffer = true;
                selmove = selup = seldown = null;
                Invalidate();

                if (LadderChanged != null) LadderChanged(this, null);
            }
        }
        #endregion
        #region Paste
        public void Paste()
        {
            if (!Debug)
            {
                if (Buffer.Count > 0)
                {
                    var minx = Buffer.Min(_x => _x.Col);
                    var maxx = Buffer.Max(_x => _x.Col);
                    var miny = Buffer.Min(_x => _x.Row);
                    var maxy = Buffer.Max(_x => _x.Row);
                    var gapx = CurX - minx;
                    var gapy = CurY - miny;

                    if (gapx + maxx > ColumnCount - 1 || gapy + maxy > RowCount - 1) MessageBox.ShowMessageBoxOk("실패", "붙여넣을 위치가 제한을 넘어갑니다.");
                    else
                    {
                        var vt = Ladders.Where(x => x.Col >= minx + gapx && x.Col <= maxx + gapx && x.Row >= miny + gapy && x.Row <= maxy + gapy).ToList();
                        var vl = Buffer.Select(x => x.CloneWithPositionChange(x.Row + gapy, x.Col + gapx));

                        using (var tr = actmgr.CreateTransaction())
                        {
                            foreach (var v in vl)
                            {
                                var itm = GetLadder(v.Row, v.Col);

                                if (itm != null)
                                {
                                    itm.Col = v.Col;
                                    itm.Row = v.Row;
                                    itm.Code = v.Code;
                                    itm.ItemType = v.ItemType;
                                    itm.VerticalLine = v.VerticalLine;
                                    vt.Remove(itm);
                                    EditLadderAction(itm, v);
                                }
                                else AddLadderAction(v);
                            }
                        }
                        bufferSetTime = DateTime.Now;
                        bCutBuffer = false;
                        selmove = selup = seldown = null;
                        Buffer.Clear();
                        Invalidate();

                        if (LadderChanged != null) LadderChanged(this, null);
                    }
                }
            }
        }
        #endregion
        #region Detele
        public void Delete()
        {
            if (!Debug)
            {
                using (var tr = actmgr.CreateTransaction())
                {
                    foreach (var v in GetSelectItem())
                        DeleteLadderAction(v);
                }
                seldown = selmove = selup = null;
                Invalidate();
            }
        }
        #endregion
        #endregion
        #region Debug Start/Stop/Set
        #region StarDebug
        void StartDebug()
        {
            if (Program.MainForm.CurrentDocument != null)
            {
                #region Buffer Clear
                if (Buffer.Count > 0)
                {
                    UndoForce();
                    Buffer.Clear();
                    bCutBuffer = false;
                    Invalidate();
                }
                #endregion

                var doc = Program.MainForm.CurrentDocument;

                MonitorValues.Clear();
                foreach (var v in Ladders) { v.Monitor = false; v.Watch = v.Timer = 0; }

                foreach (var v in Ladders.OrderBy(x => x.Row).ThenBy(x => x.Col))
                {
                    if (v.Code != null && !v.Code.StartsWith("'"))
                    {
                        switch (v.ItemType)
                        {
                            case LadderItemType.IN_A:
                            case LadderItemType.IN_B:
                            case LadderItemType.NOT:
                            case LadderItemType.OUT_COIL:
                                MonitorValues.Add(v.Row + "," + v.Col, new MonitorValue(v) { ValueType = MonitorValueKinds.CONTACT });
                                break;

                            case LadderItemType.OUT_FUNC:
                                var cd = v.Code.ToUpper();
                                if (cd.StartsWith("TON") || cd.StartsWith("TAON") || cd.StartsWith("TOFF") || cd.StartsWith("TAOFF") || cd.StartsWith("TMON") || cd.StartsWith("TAMON"))
                                    MonitorValues.Add(v.Row + "," + v.Col, new MonitorValue(v) { ValueType = MonitorValueKinds.TIMER });
                                else
                                    MonitorValues.Add(v.Row + "," + v.Col, new MonitorValue(v) { ValueType = MonitorValueKinds.CONTACT });
                                break;

                            case LadderItemType.RISING_EDGE:
                            case LadderItemType.FALLING_EDGE:
                                MonitorValues.Add(v.Row + "," + v.Col, new MonitorValue(v) { ValueType = MonitorValueKinds.CONTACT });
                                break;
                        }
                    }

                    if (v.Code.StartsWith("''") && doc.ValidSymbol(v.Code.Substring(2).Trim()))
                    {
                        var saddr = Program.MainForm.CurrentDocument.GetSymbolAddress(v.Code.Substring(2).Trim());
                        var addr = AddressInfo.Parse(saddr);
                        if (addr != null)
                        {
                            if (addr.Type == AddressType.WORD)
                                MonitorValues.Add(v.Row + "," + v.Col, new MonitorValue(v) { ValueType = MonitorValueKinds.WORD });
                            else if (addr.Type == AddressType.FLOAT)
                                MonitorValues.Add(v.Row + "," + v.Col, new MonitorValue(v) { ValueType = MonitorValueKinds.FLOAT });
                            else if (addr.Type == AddressType.BIT || addr.Type == AddressType.BIT_WORD)
                                MonitorValues.Add(v.Row + "," + v.Col, new MonitorValue(v) { ValueType = MonitorValueKinds.CONTACT });
                        }
                    }
                }
            }
        }
        #endregion
        #region StopDebug
        void StopDebug()
        {
            foreach (var v in Ladders) { v.Monitor = false; v.Watch = v.Timer = 0; }
        }
        #endregion
        #region SetDebug
        public void SetDebug(List<DebugInfo> dbgs)
        {
            var dic = dbgs.ToDictionary(x => x.Row + "," + x.Column);

            foreach (var vk in dic.Keys)
            {
                if (MonitorValues.ContainsKey(vk))
                {
                    var mon = MonitorValues[vk];
                    var v = dic[vk];

                    if (v.Type == DebugInfoType.Contact && mon.ValueType == MonitorValueKinds.CONTACT)
                    {
                        mon.Contact = v.Contact;

                        var itm = GetLadder(v.Row, v.Column);
                        if (itm != null) { itm.Monitor = mon.Contact; }
                    }

                    if (v.Type == DebugInfoType.Timer && mon.ValueType == MonitorValueKinds.TIMER)
                    {
                        mon.Contact = v.Contact;
                        mon.Timer = v.Timer;

                        var itm = GetLadder(v.Row, v.Column);
                        if (itm != null) { itm.Monitor = mon.Contact; itm.Timer = mon.Timer; }
                    }

                    if (v.Type == DebugInfoType.Word && mon.ValueType == MonitorValueKinds.WORD)
                    {
                        mon.Word = v.Word;

                        var itm = GetLadder(v.Row, v.Column);
                        if (itm != null) { itm.Watch = mon.Word; }
                    }

                    if (v.Type == DebugInfoType.Float && mon.ValueType == MonitorValueKinds.FLOAT)
                    {
                        mon.Float = v.Float;

                        var itm = GetLadder(v.Row, v.Column);
                        if (itm != null) { itm.WatchF = mon.Float; }
                    }
                }
            }
        }
        #endregion
        #endregion
        #endregion
    }

    #region class : AfterItem
    public class AfterItem
    {
        public LadderItem item;
        public Rectangle Bounds;
    }
    #endregion
    #region class : Action
    #region Add
    public class LadderAddAction : GuiLabs.Undo.AbstractAction
    {
        LadderEditorControl editor;
        LadderItem newitm;

        public LadderAddAction(LadderEditorControl editor, LadderItem newitm)
        {
            this.editor = editor;
            this.newitm = newitm;
        }

        protected override void ExecuteCore()
        {
            editor.Ladders.Add(newitm);
        }

        protected override void UnExecuteCore()
        {
            editor.Ladders.Remove(newitm);
        }
    }
    #endregion
    #region Delete
    public class LadderDeleteAction : GuiLabs.Undo.AbstractAction
    {
        LadderEditorControl editor;
        LadderItem delitm;

        public LadderDeleteAction(LadderEditorControl editor, LadderItem delitm)
        {
            this.editor = editor;
            this.delitm = delitm;
        }

        protected override void ExecuteCore()
        {
            editor.Ladders.Remove(delitm);
        }

        protected override void UnExecuteCore()
        {
            editor.Ladders.Add(delitm);
        }
    }
    #endregion
    #region Edit
    public class LadderEditAction : GuiLabs.Undo.AbstractAction
    {
        LadderEditorControl editor;
        LadderItem targetItem;
        LadderItem newval;
        LadderItem oldval;

        public LadderEditAction(LadderEditorControl editor, LadderItem targetItem, LadderItem newItem)
        {
            this.editor = editor;
            this.targetItem = targetItem;
            this.newval = newItem;
            this.oldval = targetItem.Clone();
        }

        protected override void ExecuteCore()
        {
            targetItem.Col = newval.Col;
            targetItem.Row = newval.Row;
            targetItem.Code = newval.Code;
            targetItem.ItemType = newval.ItemType;
            targetItem.VerticalLine = newval.VerticalLine;
        }

        protected override void UnExecuteCore()
        {
            targetItem.Col = oldval.Col;
            targetItem.Row = oldval.Row;
            targetItem.Code = oldval.Code;
            targetItem.ItemType = oldval.ItemType;
            targetItem.VerticalLine = oldval.VerticalLine;
        }
    }
    #endregion
    #endregion
    #region class : MonitorValue
    public class MonitorValue
    {
        public MonitorValueKinds ValueType { get; set; }
        public int Word { get; set; }
        public float Float { get; set; }
        public int Timer { get; set; }
        public bool Contact { get; set; }
        public int Row { get { return (Item != null ? Item.Row : -1); } }
        public int Col { get { return (Item != null ? Item.Col : -1); } }
        public LadderItem Item { get; private set; }

        public MonitorValue(LadderItem v)
        {
            this.Item = v;
        }
    }
    #endregion
    #region enum : MonitorValueKinds
    public enum MonitorValueKinds { WORD, CONTACT, TIMER, FLOAT }
    #endregion
    #region enum : LadderDisplayKinds
    public enum LadderDisplayKinds { DEC, HEX, BIN }
    #endregion
}
*/