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

        public JsonResult GetData()
        {
            MyEmployeeDataEntities entities = new MyEmployeeDataEntities();

            return Json(new { data = entities.EMP_Example.ToList() }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddEmployee()
        {

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




    }
}