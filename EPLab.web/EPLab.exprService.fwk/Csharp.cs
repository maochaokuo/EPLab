using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLab.exprService.fwk
{
    public enum CsOperator
    {
        MATH_POW,
    }
    public class Csharp
    {
        public static string operator2sourceCode(string operatorEnumS)
        {
            string ret = "";
            switch(operatorEnumS)
            {
                case "MATH_POW":
                    ret = "Math.Pow";
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
