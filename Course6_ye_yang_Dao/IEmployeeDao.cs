using System;
namespace Course6_ye_yang_Dao
{
    public interface IEmployeeDao
    {
        void DeleteEmployee(string id);
        System.Data.DataTable GetDataByCodeType(string type);
        System.Data.DataTable GetEmployeeByID(string id);
        System.Data.DataTable GetManagerID();
        System.Data.DataTable GetSearchResultByArg(Course6_ye_yang_Model.Employee.EmployeeSearchArg arg);
        int InsertEmployee(Course6_ye_yang_Model.Employee.Employee arg);
        object NullToDBNullValue(object obj, bool convEmpty = false);
        void UpdateEmployee(Course6_ye_yang_Model.Employee.Employee arg);
    }
}
