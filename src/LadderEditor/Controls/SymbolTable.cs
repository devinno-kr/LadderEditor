using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Extensions;
using Devinno.Forms.Themes;
using Devinno.Forms.Utils;
using Devinno.PLC.Ladder;
using Devinno.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LM = LadderEditor.Tools.LangTool;

namespace LadderEditor.Controls
{
    public class SymbolTable : DvControl
    {
        #region Const
        private int ItemHeight = 20;
        #endregion

        #region Member Variable
        private Scroll scrollP = new Scroll();
        private Scroll scrollM = new Scroll();
        private Scroll scrollT = new Scroll();
        private Scroll scrollC = new Scroll();
        private Scroll scrollD = new Scroll();

        private List<SymbolInfo> ItemsP = new List<SymbolInfo>();
        private List<SymbolInfo> ItemsM = new List<SymbolInfo>();
        private List<SymbolInfo> ItemsT = new List<SymbolInfo>();
        private List<SymbolInfo> ItemsC = new List<SymbolInfo>();
        private List<SymbolInfo> ItemsD = new List<SymbolInfo>();
        #endregion

        #region Constructor
        public SymbolTable()
        {
            scrollP = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollP.GetScrollTotal = () => ItemsP.Count * ItemHeight;
            scrollP.GetScrollTick = () => ItemHeight;
            scrollP.GetScrollView = () => this.Height - 48;
            scrollP.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollP.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };

            scrollM = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollM.GetScrollTotal = () => ItemsM.Count * ItemHeight;
            scrollM.GetScrollTick = () => ItemHeight;
            scrollM.GetScrollView = () => this.Height - 48;
            scrollM.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollM.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };

            scrollT = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollT.GetScrollTotal = () => ItemsT.Count * ItemHeight;
            scrollT.GetScrollTick = () => ItemHeight;
            scrollT.GetScrollView = () => this.Height - 48;
            scrollT.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollT.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };

            scrollC = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollC.GetScrollTotal = () => ItemsC.Count * ItemHeight;
            scrollC.GetScrollTick = () => ItemHeight;
            scrollC.GetScrollView = () => this.Height - 48;
            scrollC.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollC.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };

            scrollD = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollD.GetScrollTotal = () => ItemsD.Count * ItemHeight;
            scrollD.GetScrollTick = () => ItemHeight;
            scrollD.GetScrollView = () => this.Height - 48;
            scrollD.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollD.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };

        }
        #endregion

        #region Override
        #region OnThemeDraw
        protected override void OnThemeDraw(PaintEventArgs e, DvTheme Theme)
        {
            #region Var
            var ScrollBorderColor = Theme.GetBorderColor(Theme.ScrollBarColor, BackColor);
            var rndBox = RoundType.L;
            var rndScroll = RoundType.R;
            #endregion
            #region Init
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var p = new Pen(Color.Black);
            var br = new SolidBrush(Color.Black);
            var ft = new Font("나눔고딕", 8);
            #endregion

            Areas((rtContent, rts) =>
            {
                var m = new string[] { "P", "M", "T", "C", "D" };
                var scrolls = new Scroll[] { scrollP, scrollM, scrollT, scrollC, scrollD };
                var lsItems = new List<SymbolInfo>[] { ItemsP, ItemsM, ItemsT, ItemsC, ItemsD };

                for (int i = 0; i < 5; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];
                    var items = lsItems[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        #region Background
                        {
                            br.Color = Color.FromArgb(30, 30, 30);

                            e.Graphics.FillRoundRectangleT(br, rtTitle, 5);
                            e.Graphics.FillRoundRectangleRB(br, rtScroll, 5);
                            e.Graphics.FillRectangle(br, rtCol);

                            e.Graphics.DrawLine(Pens.Black, rtTitle.Left, rtTitle.Bottom, rtTitle.Right, rtTitle.Bottom);
                            e.Graphics.DrawLine(Pens.Black, rtTitle.Left, rtCol1.Bottom, rtTitle.Right, rtCol1.Bottom);
                            e.Graphics.DrawLine(Pens.Black, rtCol2.Left, rtCol1.Top, rtCol2.Left, rtCol1.Bottom);
                            e.Graphics.DrawLine(Pens.Black, rtSC.Left, rtCol1.Top, rtSC.Left, rtCol1.Bottom);
                            e.Graphics.DrawLine(Pens.Black, rtScroll.Left, rtScroll.Top, rtScroll.Left, rtScroll.Bottom);

                            Theme.DrawText(e.Graphics, $"{m[i]} {LM.Area}", Font, Color.FromArgb(200, 200, 200), rtTitle);
                            Theme.DrawText(e.Graphics, LM.Address, Font, Color.FromArgb(200, 200, 200), rtCol1);
                            Theme.DrawText(e.Graphics, LM.Name, Font, Color.FromArgb(200, 200, 200), rtCol2);
                        }
                        #endregion

                        #region Rows
                        e.Graphics.SetClip(new RectangleF(rtRows.X, rtRows.Y + 1, rtRows.Width, rtRows.Height - 1));
                        loop(rtRows, (idx, rtr, itm) =>
                        {
                            var rtAddr = new RectangleF(rtCol1.X, rtr.Y, rtCol1.Width, rtr.Height);
                            var rtSym = new RectangleF(rtCol2.X, rtr.Y, rtCol2.Width, rtr.Height);

                            Theme.DrawText(e.Graphics, itm.Address, ft, Color.White, rtAddr);
                            Theme.DrawText(e.Graphics, itm.SymbolName, ft, Color.White, rtSym);

                        }, scroll, items);
                        e.Graphics.ResetClip();
                        #endregion

                        #region Scroll
                        {
                            Theme.DrawBox(e.Graphics, rtScroll, Theme.ScrollBarColor, ScrollBorderColor, rndScroll, Box.FlatBox(true));

                            e.Graphics.SetClip(Util.FromRect(rtScroll.Left, rtScroll.Top + 0, rtScroll.Width, rtScroll.Height - 0));

                            var cCur = Theme.ScrollCursorOffColor;
                            if (scroll.IsScrolling || scroll.IsTouchMoving) cCur = Theme.ScrollCursorOnColor;

                            var rtcur = scroll.GetScrollCursorRect(rtScroll);
                            if (rtcur.HasValue) Theme.DrawBox(e.Graphics, Util.INT(rtcur.Value), cCur, ScrollBorderColor, RoundType.All, Box.FlatBox(true));

                            e.Graphics.ResetClip();
                        }
                        #endregion

                    });

                    e.Graphics.DrawRoundRectangle(Pens.Black, Util.INT(rt), 5);
                }

            });

            #region Dispose
            br.Dispose();
            p.Dispose();
            ft.Dispose();
            #endregion
            base.OnThemeDraw(e, Theme);
        }
        #endregion
        #region OnMouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int x = e.X, y = e.Y;

            Areas((rtContent, rts) =>
            {
                var scrolls = new Scroll[] { scrollP, scrollM, scrollT, scrollC, scrollD };

                for (int i = 0; i < 5; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        scroll.MouseDown(x, y, rtScroll);
                    });
                }

            });

            Invalidate();
            base.OnMouseDown(e);
        }
        #endregion
        #region OnMouseUp
        protected override void OnMouseUp(MouseEventArgs e)
        {
            int x = e.X, y = e.Y;

            Areas((rtContent, rts) =>
            {
                var scrolls = new Scroll[] { scrollP, scrollM, scrollT, scrollC, scrollD };

                for (int i = 0; i < 5; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        scroll.MouseUp(x, y);
                    });
                }

            });

            Invalidate();
            base.OnMouseUp(e);
        }
        #endregion
        #region OnMouseMove
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int x = e.X, y = e.Y;
            bool bInv = false;

            Areas((rtContent, rts) =>
            {
                var scrolls = new Scroll[] { scrollP, scrollM, scrollT, scrollC, scrollD };

                for (int i = 0; i < 5; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        scroll.MouseMove(x, y, rtScroll);
                    });

                    if (scroll.IsScrolling || scroll.IsTouchMoving || scroll.IsTouchScrolling) bInv |= true;
                }

            });

            if (bInv) Invalidate();
            base.OnMouseMove(e);
        }
        #endregion
        #region OnMouseWheel
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int x = e.X, y = e.Y;

            Areas((rtContent, rts) =>
            {
                var scrolls = new Scroll[] { scrollP, scrollM, scrollT, scrollC, scrollD };

                for (int i = 0; i < 5; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        if (CollisionTool.Check(rt, e.Location))
                        {
                            scroll.MouseWheel(e.Delta, rtScroll);
                            Invalidate();
                        }
                    });
                }

            });

            Invalidate();
            base.OnMouseWheel(e);
        }
        #endregion
        #endregion

        #region Method
        #region Areas
        void Areas(Action<RectangleF, RectangleF[]> act)
        {
            var rtContent = GetContentBounds();
            var lsc = new List<SizeInfo>();

            lsc.Add(new SizeInfo(DvSizeMode.Percent, 20));
            lsc.Add(new SizeInfo(DvSizeMode.Pixel, 10));
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 20));
            lsc.Add(new SizeInfo(DvSizeMode.Pixel, 10));
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 20));
            lsc.Add(new SizeInfo(DvSizeMode.Pixel, 10));
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 20));
            lsc.Add(new SizeInfo(DvSizeMode.Pixel, 10));
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 20));

            var rts = Util.DevideSizeH(rtContent, lsc);

            act(rtContent, new RectangleF[] { rts[0], rts[2], rts[4], rts[6], rts[8] });
        }
        #endregion
        #region AreasTBL
        void AreasTBL(RectangleF rt, Action<Rectangle, Rectangle, Rectangle, Rectangle, Rectangle, Rectangle, Rectangle> act)
        {
            var rh = ItemHeight;

            var lsc = new List<SizeInfo>();
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 50));
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 50));
            lsc.Add(new SizeInfo(DvSizeMode.Pixel, 14));
            var rts = Util.DevideSizeH(new RectangleF(rt.X, rt.Y + rh, rt.Width, rh), lsc);

            var rtTitle = new RectangleF(rt.X, rt.Y, rt.Width, rh);
            var rtCol = new RectangleF(rt.X, rt.Y + rh, rt.Width, rh);
            var rtCol1 = rts[0];
            var rtCol2 = rts[1];
            var rtSC = rts[2];
            var rtRows = new RectangleF(rt.X, rtCol1.Bottom, rt.Width, rt.Height - (rh * 2));
            var rtScroll = new RectangleF(rtSC.Left, rtCol1.Bottom, rtSC.Width, rt.Height - (rh * 2));

            act(Util.INT(rtTitle),
                Util.INT(rtCol), Util.INT(rtCol1), Util.INT(rtCol2), Util.INT(rtSC),
                Util.INT(rtRows), Util.INT(rtScroll));
        }
        #endregion

        #region SetItems
        public void SetItems(List<SymbolInfo> Items)
        {
            ItemsP.Clear();
            ItemsM.Clear();
            ItemsT.Clear();
            ItemsC.Clear();
            ItemsD.Clear();

            AddressInfo addr;
            var lsp = Items.Where(x => AddressInfo.TryParse(x.Address, out addr) && addr.Code == "P").Select(x => new { ai = AddressInfo.Parse(x.Address), v = x }).ToList();
            var lsm = Items.Where(x => AddressInfo.TryParse(x.Address, out addr) && addr.Code == "M").Select(x => new { ai = AddressInfo.Parse(x.Address), v = x }).ToList();
            var lst = Items.Where(x => AddressInfo.TryParse(x.Address, out addr) && addr.Code == "T").Select(x => new { ai = AddressInfo.Parse(x.Address), v = x }).ToList();
            var lsc = Items.Where(x => AddressInfo.TryParse(x.Address, out addr) && addr.Code == "C").Select(x => new { ai = AddressInfo.Parse(x.Address), v = x }).ToList();
            var lsd = Items.Where(x => AddressInfo.TryParse(x.Address, out addr) && addr.Code == "D").Select(x => new { ai = AddressInfo.Parse(x.Address), v = x }).ToList();

            ItemsP.AddRange(lsp.OrderBy(x => x.ai.Index).ThenBy(x => x.ai.BitIndex).Select(x => x.v));
            ItemsM.AddRange(lsm.OrderBy(x => x.ai.Index).ThenBy(x => x.ai.BitIndex).Select(x => x.v));
            ItemsT.AddRange(lst.OrderBy(x => x.ai.Index).ThenBy(x => x.ai.BitIndex).Select(x => x.v));
            ItemsC.AddRange(lsc.OrderBy(x => x.ai.Index).ThenBy(x => x.ai.BitIndex).Select(x => x.v));
            ItemsD.AddRange(lsd.OrderBy(x => x.ai.Index).ThenBy(x => x.ai.BitIndex).Select(x => x.v));

            Invalidate();
        }
        #endregion

        #region loop
        private void loop(RectangleF rtBox, Action<int, RectangleF, SymbolInfo> act, Scroll scroll, List<SymbolInfo> Items)
        {
            if (!IsDisposed)
            {
                var sc = scroll.ScrollPosition;
                var spos = Convert.ToInt32(scroll.ScrollPositionWithOffset);

                var si = Convert.ToInt32(Math.Floor((double)(sc - scroll.TouchOffset) / (double)ItemHeight));
                var cnt = Convert.ToInt32(Math.Ceiling((double)(rtBox.Height - Math.Min(0, scroll.TouchOffset)) / (double)ItemHeight));
                var ei = si + cnt;

                using (var g = CreateGraphics())
                {
                    for (int i = Math.Max(0, si); i < ei + 1 && i < Items.Count; i++)
                    {
                        var itm = Items[i];
                        var rt = Util.FromRect(rtBox.Left, spos + rtBox.Top + (ItemHeight * i), rtBox.Width, ItemHeight);
                        if (CollisionTool.Check(Util.FromRect(rt.Left + 1, rt.Top + 1, rt.Width - 2, rt.Height - 2), rtBox)) act(i, rt, itm);
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}
