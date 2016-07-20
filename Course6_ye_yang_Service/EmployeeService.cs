using Course6_ye_yang_Model.Employee;
using Course6_ye_yang_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course6_ye_yang_Model;
using System.Web.Mvc;
using Course6_ye_yang_Dao;

namespace Course6_ye_yang_Service
{
    public class EmployeeService : Course6_ye_yang_Service.IEmployeeService
    {
        
        /// <summary>
        /// 定義Dao來操作資料庫
        /// </summary>        
        public IEmployeeDao employeeDao { get; set; }

        /// <summary>
        /// 取得emp by 表單上的data
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public List<EmployeeSearchResult> GetSearchResultByArg(EmployeeSearchArg arg)
        {
            DataTable dt = employeeDao.GetSearchResultByArg(arg);
            return TableFactory.Table2EmployeeSearchResult(dt);
        }

        /// <summary>
        /// 取得所有職稱(Employee.Title)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetTitle()
        {
            DataTable dt = employeeDao.GetDataByCodeType("TITLE");
            return TableFactory.Table2SelectListItem(dt);
        }

        /// <summary>
        /// 取得所有國家(Employee.Country)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCountry()
        {
            DataTable dt = employeeDao.GetDataByCodeType("COUNTRY");
            return TableFactory.Table2SelectListItem(dt);
        }

        /// <summary>
        /// 取得所有城市(Employee.City)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCity()
        {
            DataTable dt = employeeDao.GetDataByCodeType("CITY");
            return TableFactory.Table2SelectListItem(dt);
        }

        /// <summary>
        /// 取得所有性別(Employee.Gender)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetGender()
        {
            DataTable dt = employeeDao.GetDataByCodeType("GENDER");
            return TableFactory.Table2SelectListItem(dt);
        }

        /// <summary>
        /// 取得所有主管ID(Employee.ManagerID)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetManagerID()
        {
            DataTable dt = employeeDao.GetManagerID();
            return TableFactory.Table2SelectListItem(dt);
        }

        /// <summary>
        /// 新增一筆Employee
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public int InsertEmployee(Employee arg)
        {
            return employeeDao.InsertEmployee(arg);
        }

        /// <summary>
        /// 取得emp資訊 by 輸入的ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeByID(string id)
        {
            DataTable dt = employeeDao.GetEmployeeByID(id);

            return TableFactory.Table2EmployeeInsertArg(dt);
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="arg"></param>
        public void UpdateEmployee(Employee arg)
        {
            employeeDao.UpdateEmployee(arg);
        }

        /// <summary>
        /// 刪除By ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(string id)
        {
            employeeDao.DeleteEmployee(id);
        }


    }
}
