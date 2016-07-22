using Course6_ye_yang_Model.Employee;
using Course6_ye_yang_Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course6_ye_yang.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService { get;set;}

        public ActionResult Index()
        {
            return RedirectToAction("SearchEmployee");
        }

        public ActionResult SearchEmployee()
        {
            //Create DropdownList
            ViewBag.DropdownType = JsonConvert.SerializeObject(employeeService.GetTitle());
            return View(new EmployeeSearchArg());
        }

        [HttpPost]
        public ActionResult SearchEmployee(EmployeeSearchArg arg)
        {
            //Create DropdownList
            ViewBag.DropdownType = JsonConvert.SerializeObject(employeeService.GetTitle());
            //This is Results
            List<EmployeeSearchResult> employeeSearchResult = employeeService.GetSearchResultByArg(arg);
            ViewBag.EmployeeSearchResultJSON = JsonConvert.SerializeObject(employeeSearchResult);
            //Arg should be shown
            ViewBag.ViewEmployeeId = arg.EmployeeId;
            ViewBag.ViewEmployeeName = arg.EmployeeName;
            ViewBag.ViewEndHireDate = arg.EndHireDate;
            ViewBag.ViewStartHireDate = arg.StartHireDate;
            ViewBag.ViewTitle = arg.Title;            
            return View(arg);
        }

        public ActionResult InsertEmployee()
        {
            ViewBag.Type = employeeService.GetTitle();
            ViewBag.Country = employeeService.GetCountry();
            ViewBag.City = employeeService.GetCity();
            ViewBag.Gender = employeeService.GetGender();
            ViewBag.ManagerID = employeeService.GetManagerID();
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult InsertEmployee(Employee arg)
        {
            ViewBag.Type = employeeService.GetTitle();
            ViewBag.Country = employeeService.GetCountry();
            ViewBag.City = employeeService.GetCity();
            ViewBag.Gender = employeeService.GetGender();
            ViewBag.ManagerID = employeeService.GetManagerID();
            if (ModelState.IsValid)
            {
                ViewBag.Successful = employeeService.InsertEmployee(arg);
            }
            return View(new Employee());
        }

        [HttpGet]
        public ActionResult UpdateEmployee(string id)
        {
            ViewBag.Type = employeeService.GetTitle();
            ViewBag.ViewCountry = employeeService.GetCountry();
            ViewBag.ViewCity = employeeService.GetCity();
            ViewBag.ViewGender = employeeService.GetGender();
            ViewBag.ViewManagerID = employeeService.GetManagerID();
            if (id != null)
            {
                try
                {
                    Employee arg = employeeService.GetEmployeeByID(id);
                    arg.EmployeeID = Convert.ToInt32(id);
                    ViewBag.ID = Convert.ToInt32(id);
                    return View(arg);
                }
                catch (Exception e)
                {
                    return RedirectToAction("SearchEmployee");
                }                  
            }
            return RedirectToAction("SearchEmployee");      
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee arg)
        {
            ViewBag.Type = employeeService.GetTitle();
            ViewBag.ViewCountry = employeeService.GetCountry();
            ViewBag.ViewCity = employeeService.GetCity();
            ViewBag.ViewGender = employeeService.GetGender();
            ViewBag.ViewManagerID = employeeService.GetManagerID();
            if (ModelState.IsValid)
            {
                employeeService.UpdateEmployee(arg);
            }

            return View(arg);
        }

        [HttpPost()]
        public JsonResult DeleteEmployee(string EmployeeID)
        {
            try
            {
                employeeService.DeleteEmployee(EmployeeID);
                return this.Json(true);
            }

            catch (Exception)
            {
                return this.Json(false);
            }
        }

    }
}
