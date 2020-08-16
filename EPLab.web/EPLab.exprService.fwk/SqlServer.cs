using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLab.exprService.fwk
{
    public enum SqlOperator
    {
        SQL_EQUAL,
        SQL_NOTEQUAL,
        SQL_GREATER,
        SQL_SMALLER,
        SQL_GREATEROREQUAL,
        SQL_SMALLEROREQUAL,
    }
    public class SqlServer
    {
        public static string operator2sourceCode(string operatorEnumS)
        {
            string ret = "";
            switch(operatorEnumS)
            {
                case "SQL_EQUAL":
                    ret = "=";
                    break;
                case "SQL_NOTEQUAL":
                    ret = "!=";
                    break;
                case "SQL_GREATER":
                    ret = ">";
                    break;
                case "SQL_SMALLER":
                    ret = "<";
                    break;
                case "SQL_GREATEROREQUAL":
                    ret = ">=";
                    break;
                case "SQL_SMALLEROREQUAL":
                    ret = "<=";
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
