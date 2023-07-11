using Devinno.Forms.Controls;
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
    public class DvValueLabelPath : DvValueLabel
    {
        #region Properties
        #region Value
        private string sValue = "";
        public string Value
        {
            get => sValue;
            set
            {
                if (sValue != value)
                {
                    sValue = value;
                    Invalidate();
                }
            }
        }
        #endregion
        #endregion

        #region Override
        #region DrawValue
        public override void DrawValue(Graphics g, DvTheme theme, RectangleF rtValue)
        {
            if (!string.IsNullOrWhiteSpace(Value))
            {
                var vc = ValueColor ?? theme.LabelColor;
                //theme.DrawText(g, Value, Font, ForeColor, rtValue);
                var rt = Util.INT(rtValue);
                rt.Inflate(-7, 0);
                TextRenderer.DrawText(g, Value, Font, rt, ForeColor, vc, TextFormatFlags.PathEllipsis | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
        }
        #endregion
        #endregion
    }
}
