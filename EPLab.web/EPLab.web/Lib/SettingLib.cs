using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPLab.web.Lib
{
    public class SettingLib
    {
        private static string _ConnServer = "";
        public static string ConnServer { 
            get { 
                return _ConnServer; 
            }
            set { 
                _ConnServer = value; 
            }
        }
        public static string ConnDB { get; set; }
        public static string ConnID { get; set; }
        public static string ConnPass { get; set; }
    }
}
