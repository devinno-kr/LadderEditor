using Devinno.Forms;
using Devinno.Forms.Containers;
using Devinno.Forms.Themes;
using Devinno.Forms.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LadderEditor.Controls
{
    public class InputPanel : DvContainer
    {
        protected override void OnThemeDraw(PaintEventArgs e, DvTheme Theme)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var rt = new Rectangle(0, 0, this.Width - 1, this.Height - 2);
            var cB = Theme.GetBorderColor(Theme.InputColor, BackColor);
            var cF = Theme.InputColor;
            Theme.DrawBox(e.Graphics,rt, cF, cB, RoundType.All, Box.LabelBox(Embossing.FlatConcave, 1));

            base.OnThemeDraw(e, Theme);
        }
    }
}
