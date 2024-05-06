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




        }
}