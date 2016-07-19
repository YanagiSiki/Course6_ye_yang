using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course6_ye_yang_Dao
{
    public class EmployeeTestDao : Course6_ye_yang_Dao.IEmployeeDao
    {
        public void DeleteEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetDataByCodeType(string type)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetEmployeeByID(string id)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetManagerID()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetSearchResultByArg(Course6_ye_yang_Model.Employee.EmployeeSearchArg arg)
        {
            throw new NotImplementedException();
        }

        public int InsertEmployee(Course6_ye_yang_Model.Employee.Employee arg)
        {
            throw new NotImplementedException();
        }

        public object NullToDBNullValue(object obj, bool convEmpty = false)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Course6_ye_yang_Model.Employee.Employee arg)
        {
            throw new NotImplementedException();
        }
    }
}
