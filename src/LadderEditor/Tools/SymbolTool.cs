using Devinno.PLC.Ladder;
using LadderEditor.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadderEditor.Tools
{
    public class SymbolTool
    {
        #region InputLineCheck
        public static SymbolInputLineCheck InputLineCheck(FormSymbol.Result Data, string s)
        {
            var ret = new SymbolInputLineCheck() { Success = true };
            var ls = s.Split(new char[] { ',', ' ' }).Select(x => x.Trim()).Where(x => x != "").ToList();

            if (ls.Count == 2)
            {
                var vlsName = Data.Symbols.Select(x => x.SymbolName);
                var vlsAddress = Data.Symbols.Select(x => x.Address);
                var addr = ls[0].ToUpper();
                var name = ls[1];
                if (!vlsName.Contains(name))
                {
                    if (!vlsAddress.Contains(addr))
                    {
                        if (addr.Length >= 2)
                        {
                            int n;
                            var code = addr.Substring(0, 1).ToUpper();
                            var ns = addr.Substring(1);
                            var cnt = GetCount(Data, code);
                            if ((code == "P" || code == "M" || code == "T" || code == "C" || code == "D" || code == "R"))
                            {
                                if (int.TryParse(ns, out n) && n >= 0 && n < cnt)
                                {
                                    ret.SymbolName = name;
                                    ret.Address = addr;
                                    ret.Success = true;
                                    ret.Message = "";
                                }
                                else
                                {
                                    ret.Success = false;
                                    ret.Message = code + "영역은 0 ~ " + (cnt - 1) + " 까지 사용 가능합니다.";
                                }
                            }
                            else
                            {
                                ret.Success = false;
                                ret.Message = "유효한 영역 코드가 아닙니다.";
                            }
                        }
                        else
                        {
                            ret.Success = false;
                            ret.Message = "잘못된 주소입니다.";
                        }
                    }
                    else
                    {
                        ret.Success = false;
                        ret.Message = "이미 존재하는 주소입니다.";
                    }
                }
                else
                {
                    ret.Success = false;
                    ret.Message = "이미 존재하는 이름입니다.";
                }
            }
            else
            {
                ret.Success = false;
                ret.Message = "잘못된 입력 형식입니다.";
            }
            return ret;
        }
        #endregion
        #region AddressCheck
        public static SymbolAddressCheck AddressCheck(FormSymbol.Result Data, string addr)
        {
            var ret = new SymbolAddressCheck() { Success = true };
            var vlsAddress = Data.Symbols.Select(x => x.Address);
            if (!vlsAddress.Contains(addr))
            {
                if (addr != null && addr.Length >= 2)
                {
                    int n;
                    var code = addr.Substring(0, 1).ToUpper();
                    var ns = addr.Substring(1);
                    var cnt = GetCount(Data, code);
                    if ((code == "P" || code == "M" || code == "T" || code == "C" || code == "D" || code == "R"))
                    {
                        if (int.TryParse(ns, out n) && n >= 0 && n < cnt)
                        {
                            ret.Success = true;
                            ret.Message = "";
                        }
                        else
                        {
                            ret.Success = false;
                            ret.Message = code + "영역은 0 ~ " + (cnt - 1) + " 까지 사용 가능합니다.";
                        }
                    }
                    else
                    {
                        ret.Success = false;
                        ret.Message = "유효한 영역 코드가 아닙니다.";
                    }
                }
                else
                {
                    ret.Success = false;
                    ret.Message = "잘못된 주소입니다.";
                }
            }
            else
            {
                ret.Success = false;
                ret.Message = "이미 존재하는 주소입니다.";
            }
            return ret;
        }
        #endregion
        #region GetCount
        public static int? GetCount(FormSymbol.Result Data, string code)
        {
            int? ret = null;
            switch (code.ToUpper())
            {
                case "P": ret = Data.P_Count; break;
                case "M": ret = Data.M_Count; break;
                case "T": ret = Data.T_Count; break;
                case "C": ret = Data.C_Count; break;
                case "D": ret = Data.D_Count; break;
                case "R": ret = Data.R_Count; break;
            }
            return ret;
        }

        public static int? GetCount(LadderDocument Doc, string code)
        {
            int? ret = null;
            switch (code.ToUpper())
            {
                case "P": ret = Doc.P_Count; break;
                case "M": ret = Doc.M_Count; break;
                case "T": ret = Doc.T_Count; break;
                case "C": ret = Doc.C_Count; break;
                case "D": ret = Doc.D_Count; break;
                case "R": ret = Doc.R_Count; break;
            }
            return ret;
        }
        #endregion
    }

    public class SymbolInputLineCheck
    {
        public string SymbolName { get; set; }
        public string Address { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class SymbolAddressCheck
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
