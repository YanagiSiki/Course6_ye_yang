using Course6_ye_yang_Dao;
using Course6_ye_yang_Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Course6_ye_yang_Service
{
    public class EmployeeServiceTest : Course6_ye_yang_Service.IEmployeeService
    {
        /// <summary>
        /// 定義Dao來操作資料庫
        /// </summary>        
        public IEmployeeDao employeeDao { get; set; }

        /// <summary>
        /// 定義Dao來操作資料庫
        /// </summary>                
        public List<Employee> employees { get; set; }


        public EmployeeServiceTest()
        {
            employees = new List<Employee>();
            employees.Add(new Employee() { EmployeeID = 1, FirstName = "ABC", LastName = "DEF", Title = "0001", TitleOfCourtesy = "Mr.", HireDate = Convert.ToDateTime("2016 / 01 / 01"), BirthDate = Convert.ToDateTime("2016 / 01 / 01"), Country = "UK", City = "UK", Address = "123", Phone = "09", Gender = "M", ManagerID = "1", MonthlyPayment = 100, YearlyPayment = 100 });
            employees.Add(new Employee() { EmployeeID = 2, FirstName = "ABC", LastName = "DEF", Title = "0001", TitleOfCourtesy = "Mr.", HireDate = Convert.ToDateTime("2016 / 01 / 01"), BirthDate = Convert.ToDateTime("2016 / 01 / 01"), Country = "UK", City = "UK", Address = "123", Phone = "09", Gender = "M", ManagerID = "1", MonthlyPayment = 100, YearlyPayment = 100 });
            employees.Add(new Employee() { EmployeeID = 3, FirstName = "ABC", LastName = "DEF", Title = "0001", TitleOfCourtesy = "Mr.", HireDate = Convert.ToDateTime("2016 / 01 / 01"), BirthDate = Convert.ToDateTime("2016 / 01 / 01"), Country = "UK", City = "UK", Address = "123", Phone = "09", Gender = "M", ManagerID = "1", MonthlyPayment = 100, YearlyPayment = 100 });
            employees.Add(new Employee() { EmployeeID = 4, FirstName = "ABC", LastName = "DEF", Title = "0001", TitleOfCourtesy = "Mr.", HireDate = Convert.ToDateTime("2016 / 01 / 01"), BirthDate = Convert.ToDateTime("2016 / 01 / 01"), Country = "UK", City = "UK", Address = "123", Phone = "09", Gender = "M", ManagerID = "1", MonthlyPayment = 100, YearlyPayment = 100 });
            employees.Add(new Employee() { EmployeeID = 5, FirstName = "ABC", LastName = "DEF", Title = "0001", TitleOfCourtesy = "Mr.", HireDate = Convert.ToDateTime("2016 / 01 / 01"), BirthDate = Convert.ToDateTime("2016 / 01 / 01"), Country = "UK", City = "UK", Address = "123", Phone = "09", Gender = "M", ManagerID = "1", MonthlyPayment = 100, YearlyPayment = 100 });
        }

        /// <summary>
        /// 取得emp by 表單上的data
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public List<EmployeeSearchResult> GetSearchResultByArg(EmployeeSearchArg arg)
        {
            List<EmployeeSearchResult> Employees = new List<EmployeeSearchResult>();
            Employees.Add(new EmployeeSearchResult() { EmployeeId = 1, EmployeeName = "AAA", CodeType = "0001", HireDate = Convert.ToDateTime("2016 / 01 / 01").ToString(), Gender = "Male", Age = 100 });
            Employees.Add(new EmployeeSearchResult() { EmployeeId = 1, EmployeeName = "AAA", CodeType = "0001", HireDate = Convert.ToDateTime("2016 / 01 / 01").ToString(), Gender = "Male", Age = 100 });
            Employees.Add(new EmployeeSearchResult() { EmployeeId = 1, EmployeeName = "AAA", CodeType = "0001", HireDate = Convert.ToDateTime("2016 / 01 / 01").ToString(), Gender = "Male", Age = 100 });
            return Employees;
        }

        /// <summary>
        /// 取得所有職稱(Employee.Title)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetTitle()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem() { Text = "CEO", Value = "0001" });
            result.Add(new SelectListItem() { Text = "SALES", Value = "0002" });
            return result;
        }

        /// <summary>
        /// 取得所有國家(Employee.Country)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCountry()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem() { Text = "UK", Value = "UK" });
            result.Add(new SelectListItem() { Text = "USA", Value = "USA" });
            return result;
        }

        /// <summary>
        /// 取得所有城市(Employee.City)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCity()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem() { Text = "UK", Value = "UK" });
            result.Add(new SelectListItem() { Text = "USA", Value = "USA" });
            return result;
        }

        /// <summary>
        /// 取得所有性別(Employee.Gender)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetGender()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem() { Text = "Male", Value = "M" });
            result.Add(new SelectListItem() { Text = "Female", Value = "F" });
            return result;
        }

        /// <summary>
        /// 取得所有主管ID(Employee.ManagerID)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetManagerID()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem() { Text = "AAA", Value = "1" });
            result.Add(new SelectListItem() { Text = "BBB", Value = "2" });
            result.Add(new SelectListItem() { Text = "CCC", Value = "3" });
            return result;
        }       

        /// <summary>
        /// 新增一筆Employee
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public int InsertEmployee(Employee arg)
        {
            employees.Add(arg);
            return arg.EmployeeID;
        }

        /// <summary>
        /// 取得emp資訊 by 輸入的ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeByID(string id)
        {
            return employees[Convert.ToInt32(id)];
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="arg"></param>
        public void UpdateEmployee(Employee arg)
        {
            return;
        }

        /// <summary>
        /// 刪除By ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(string id)
        {
            employees.RemoveAt(Convert.ToInt32(id));
        }
    }
}
