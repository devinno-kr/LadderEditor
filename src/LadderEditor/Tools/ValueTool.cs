using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadderEditor.Tools
{
    public class ValueTool
    {
        #region GetHexValue
        public static int? GetHexValue(string s)
        {
            int? ret = null;

            if (s != null)
            {
                int n;
                if (s.StartsWith("0x") && int.TryParse(s.Substring(2), NumberStyles.HexNumber, null, out n))
                    ret = n;
                else if (int.TryParse(s, out n))
                    ret = n;
            }

            return ret;
        }
        #endregion
        #region GetHexString
        public static string GetHexString(int v)
        {
            return $"0x{v.ToString("X4")}";
        }
        #endregion
    }
}
