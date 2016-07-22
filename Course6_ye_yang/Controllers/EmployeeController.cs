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
            ViewBag.Type = employeeService.GetTitle();
            return View();
        }

        [HttpPost]
        public ActionResult SearchEmployee(EmployeeSearchArg arg)
        {
            ViewBag.Type = employeeService.GetTitle();
            List<EmployeeSearchResult> employeeSearchResult = employeeService.GetSearchResultByArg(arg);

            ViewBag.EmployeeSearchResultTmp = JsonConvert.SerializeObject(employeeSearchResult);
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
