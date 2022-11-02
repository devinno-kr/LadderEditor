using Devinno.Forms.Extensions;
using Devinno.Forms.Icons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadderEditor.Tools
{
    public class IconTool
    {
        public static Icon GetIcon(DvIcon ico, int width, int height, Color color)
        {
            var bmp = new Bitmap(width, height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                using (var br = new SolidBrush(color))
                {
                    g.DrawIcon(ico, br, new Rectangle(0, 0, width, height), Devinno.Forms.DvContentAlignment.MiddleCenter);
                }
            }

            return Icon.FromHandle(bmp.GetHicon());
        }
    }
}
