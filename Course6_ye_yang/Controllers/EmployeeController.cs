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
            //Initialize
            ViewBag.DropdownType = JsonConvert.SerializeObject(employeeService.GetTitle());                    
            return View(new EmployeeSearchArg());
        }

        [HttpPost]
        public ActionResult SearchEmployee(EmployeeSearchArg arg)
        {
            //Initialize
            ViewBag.DropdownType = JsonConvert.SerializeObject(employeeService.GetTitle());           
            //This is Results
            List<EmployeeSearchResult> employeeSearchResult = employeeService.GetSearchResultByArg(arg);
            ViewBag.EmployeeSearchResultJSON = JsonConvert.SerializeObject(employeeSearchResult);
            //Arg should be shown
            ViewBag.ViewArg = arg;       
            return View(arg);
        }

        public ActionResult InsertEmployee()
        {
            //InitializeDropdownList
            Initialize();
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult InsertEmployee(Employee arg)
        {
            //InitializeDropdownList
            Initialize();
            //Arg should be shown
            ViewBag.ViewArg = arg;
            if (ModelState.IsValid)
            {
                var id = employeeService.InsertEmployee(arg);
                ViewBag.Successful = id;            
                return RedirectToAction("UpdateEmployee/" + id.ToString());
            }
            return View(new Employee());
        }

        [HttpGet]
        public ActionResult UpdateEmployee(string id)
        {
            //InitializeDropdownList
            Initialize();            
            if (id != null)
            {
                try
                {
                    Employee arg = employeeService.GetEmployeeByID(id);
                    arg.EmployeeID = Convert.ToInt32(id);
                    ViewBag.ID = Convert.ToInt32(id);
                    //Arg should be shown
                    ViewBag.ViewArg = arg;
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
            //InitializeDropdownList
            Initialize();
            //Arg should be shown
            ViewBag.ViewArg = arg;
            if (ModelState.IsValid)
            {
                employeeService.UpdateEmployee(arg);
            }

            return View(arg);
        }

        private void Initialize()
        {
            ViewBag.DropdownType = JsonConvert.SerializeObject(employeeService.GetTitle());
            ViewBag.DropdownCountry = JsonConvert.SerializeObject(employeeService.GetCountry());
            ViewBag.DropdownCity = JsonConvert.SerializeObject(employeeService.GetCity());
            ViewBag.DropdownGender = JsonConvert.SerializeObject(employeeService.GetGender());
            ViewBag.DropdownManagerID = JsonConvert.SerializeObject(employeeService.GetManagerID());
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
