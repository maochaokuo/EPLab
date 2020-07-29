using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPLab.web
{
    public class ConfigManager
    {
        #region ConnectionInfo
        private static string _Server;
        public static string Server { get { return _Server; } 
            set { 
                _Server = value; 
            }  }
        public static string InitialCatalog { get; set; }
        public static string UserID { get; set; }
        public static string Password { get; set; }
        #endregion

        #region ESMSetting
        public static string ESMServer { get; set; }
        #endregion

        #region BatchSetting
        public static string BatchServer { get; set; }
        #endregion
        /* 測試使用 IDE 建置時根目錄 Start */
        //public static string AppRootPath { get; set; }
        /* 測試使用 IDE 建置時根目錄 End */
    }
}
