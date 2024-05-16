using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApplication.Controllers
{
    public class StudentInfoController : Controller
    {
        // GET: StudentInfo
        public ActionResult Index()
        {
            MyEmployeeDataEntities myEmployeeDataEntities = new MyEmployeeDataEntities();
            
            return View(myEmployeeDataEntities.EMP_Example.ToList());
        }
    }
}