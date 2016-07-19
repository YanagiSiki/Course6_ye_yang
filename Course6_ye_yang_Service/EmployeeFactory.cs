using Course6_ye_yang_Common;
using Course6_ye_yang_Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course6_ye_yang_Service
{
    public class EmployeeFactory
    {
        public IEmployeeDao GetEmployeeDao()
        {
            IEmployeeDao result;
            switch (ConfigTool.GetAppsetting("DaoInTest"))
            {
                case "0":
                    result = new EmployeeTestDao();
                    break;
                case "1":
                    result = new EmployeeDao();
                    break;
                default:
                    result = new Course6_ye_yang_Dao.EmployeeTestDao();
                    break;
            }
            return result;
        }
    }
}
