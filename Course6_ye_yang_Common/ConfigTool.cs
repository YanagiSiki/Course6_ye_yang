using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course6_ye_yang_Common
{
    public class ConfigTool
    {
        /// <summary>
        /// 取得DB連線字串
        /// </summary>
        /// <returns></returns>        
        public static string GetDBConnectionString()
        {
            return
                ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        public static string GetAppsetting(string Key)
        {
            string AppSetting = string.Empty;
            AppSetting = ConfigurationManager.AppSettings[Key];
            return AppSetting;
        }
    }
}
