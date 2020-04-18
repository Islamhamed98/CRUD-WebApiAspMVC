using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using MyProject.Models;
namespace MyProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<MvcEmployeeModel> emplist;
            HttpResponseMessage response = HttpHeaderVariables.WebApiClient.GetAsync("Employees").Result;
            emplist = response.Content.ReadAsAsync<IEnumerable<MvcEmployeeModel>>().Result;
            return View(emplist);
        } 
    
        public ActionResult Create(int id = 0)
        {
            if( id == 0 )
            {
                 return View();
            } else
            {
                HttpResponseMessage response = HttpHeaderVariables.WebApiClient.GetAsync("Employees/" + id.ToString()).Result;
                var emp = response.Content.ReadAsAsync<MvcEmployeeModel>().Result;
                return View(emp);
            }

        }

        [HttpPost]
        public ActionResult Create(MvcEmployeeModel emp)
        {
            if( emp.EmpolyeeId == 0)
            {
                HttpResponseMessage response = HttpHeaderVariables.WebApiClient.PostAsJsonAsync("Employees", emp).Result;
                TempData["Message"] = "Employee Saved Successfully !! ";
            } else
            {

                HttpResponseMessage response = HttpHeaderVariables.WebApiClient.PostAsJsonAsync("Employees/"+emp.EmpolyeeId, emp).Result;
                TempData["Message"] = "Employee Updated Successfully !! ";
            } 
            return RedirectToAction("Index");
        }

        public ActionResult Delete (int id )
        {
            HttpResponseMessage response = HttpHeaderVariables.WebApiClient.DeleteAsync("Employees/" + id).Result;
            TempData["Message"] = "Employee Deleted Successfully !! ";
            return RedirectToAction("Index");
        }


    }
}