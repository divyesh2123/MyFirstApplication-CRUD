using MyFirstApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApplication.Controllers
{
    public class DataDisplayController : Controller
    {
        // GET: DataDisplay
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 1000)]
        public ActionResult Index1()
        {
            return View();
        }

        public JsonResult GetData()
        {
            MyEmployeeDataEntities entities = new MyEmployeeDataEntities();

            return Json(new { data = entities.EMP_Example.ToList() }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddEmployee(int? id)
        {
            if(id.HasValue)
            {
                MyEmployeeDataEntities entities = new MyEmployeeDataEntities();
                var d = entities.EMP_Example.FirstOrDefault(y => y.ID == id);
                var p = new EmployeeDetails
                {
                    Address = d.Address,
                    City = d.City,
                    Name=d.Name,
                    Id=d.ID
                };
                return View(p);
            }

            return View();
        }

        [HttpPost]
        public  ActionResult Delete(int id)
        {
            MyEmployeeDataEntities entities = new MyEmployeeDataEntities();

            var d = entities.EMP_Example.FirstOrDefault(y => y.ID == id);

            entities.EMP_Example.Remove(d);

            entities.SaveChanges();

            return Json(new { success = true, message = "deleted Successfully" });

        }

        [HttpPost]
        public ActionResult AddEditEmployee(EmployeeDetails employeeDetails)
        {
            MyEmployeeDataEntities myEmployeeDataEntities = new MyEmployeeDataEntities();
            if (employeeDetails.Id >0)
            {
                var p = myEmployeeDataEntities.EMP_Example.FirstOrDefault(y => y.ID == employeeDetails.Id);

               p.Address = employeeDetails.Address;
              p.City = employeeDetails.City;
                p.Name = employeeDetails.Name;
                myEmployeeDataEntities.SaveChanges();
                return Json(new { success = true, message = "updated Successfully" });

            }
            else
            {
                EMP_Example eMP_Example = new EMP_Example();
                eMP_Example.Address = employeeDetails.Address;
                eMP_Example.ID = employeeDetails.Id;
                eMP_Example.City = employeeDetails.City;
                eMP_Example.Name = employeeDetails.Name;
                myEmployeeDataEntities.EMP_Example.Add(eMP_Example);
                myEmployeeDataEntities.SaveChanges();
                return Json(new { success = true, message = "saved Successfully" });

            }

        }




        }
}