using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Course6_ye_yang.Controllers;
using Course6_ye_yang_Model.Employee;
using System.Web.Mvc;
using Course6_ye_yang_Service;
using Course6_ye_yang_Dao;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            IEmployeeService employeeService = new EmployeeServiceTest();
            EmployeeSearchArg arg = new EmployeeSearchArg();

            //Act
            List<EmployeeSearchResult> results = employeeService.GetSearchResultByArg(arg);
            //Assert
            employeeService.GetSearchResultByArg(arg);
            Assert.AreEqual(3, results.Count);


        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            IEmployeeService employeeService = new EmployeeServiceTest();
            int titleCount;
            int countryCount;
            int cityCount;
            int genderCount;
            int managerIDCount;
            //Act
            titleCount = employeeService.GetTitle().Count;
            countryCount = employeeService.GetCountry().Count;
            cityCount = employeeService.GetCity().Count;
            genderCount = employeeService.GetGender().Count;
            managerIDCount = employeeService.GetManagerID().Count;
            //Assert			
            Assert.AreEqual(2, titleCount);
            Assert.AreEqual(2, countryCount);
            Assert.AreEqual(2, cityCount);
            Assert.AreEqual(2, genderCount);
            Assert.AreEqual(3, managerIDCount);

        }

        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            EmployeeServiceTest employeeService = new EmployeeServiceTest();            
            int preCount = employeeService.employees.Count;
            Employee arg = new Employee() { EmployeeID = 1, FirstName = "ABC", LastName = "DEF", Title = "0001", TitleOfCourtesy = "Mr.", HireDate = Convert.ToDateTime("2016 / 01 / 01"), BirthDate = Convert.ToDateTime("2016 / 01 / 01"), Country = "UK", City = "UK", Address = "123", Phone = "09", Gender = "M", ManagerID = "1", MonthlyPayment = 100, YearlyPayment = 100 };
            //Act
            employeeService.InsertEmployee(arg);
            //Assert			
            Assert.AreEqual(preCount + 1, employeeService.employees.Count);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            EmployeeServiceTest employeeService = new EmployeeServiceTest();            
            //Act            
            Employee result = employeeService.GetEmployeeByID("0");
            //Assert			
            Assert.AreEqual(result.EmployeeID, 1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            //Arrange
            EmployeeServiceTest employeeService = new EmployeeServiceTest();
            int preCount = employeeService.employees.Count;
            //Act
            employeeService.UpdateEmployee(new Employee());
            //Assert			
            Assert.AreEqual(preCount, employeeService.employees.Count);
        }

        [TestMethod]
        public void TestMethod6()
        {
            //Arrange
            EmployeeServiceTest employeeService = new EmployeeServiceTest();
            int preCount = employeeService.employees.Count;
            //Act
            employeeService.DeleteEmployee("0");
            //Assert			
            Assert.AreEqual(preCount - 1, employeeService.employees.Count);
        }
    }
}
