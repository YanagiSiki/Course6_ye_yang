using System;
namespace Course6_ye_yang_Service
{
    public interface IEmployeeService
    {
        void DeleteEmployee(string id);
        System.Collections.Generic.List<System.Web.Mvc.SelectListItem> GetCity();
        System.Collections.Generic.List<System.Web.Mvc.SelectListItem> GetCountry();
        Course6_ye_yang_Model.Employee.Employee GetEmployeeByID(string id);
        System.Collections.Generic.List<System.Web.Mvc.SelectListItem> GetGender();
        System.Collections.Generic.List<System.Web.Mvc.SelectListItem> GetManagerID();
        System.Collections.Generic.List<Course6_ye_yang_Model.Employee.EmployeeSearchResult> GetSearchResultByArg(Course6_ye_yang_Model.Employee.EmployeeSearchArg arg);
        System.Collections.Generic.List<System.Web.Mvc.SelectListItem> GetTitle();
        int InsertEmployee(Course6_ye_yang_Model.Employee.Employee arg);
        void UpdateEmployee(Course6_ye_yang_Model.Employee.Employee arg);
    }
}
