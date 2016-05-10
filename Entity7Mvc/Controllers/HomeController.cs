using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity7Mvc.Models;
using Entity7Mvc.Repository;

namespace Entity7Mvc.Controllers
{
    public class HomeController : Controller
    {
        ent6Context db = new ent6Context();
        public ActionResult Index()
        {
            List<Student> students = db.Students.ToList();
            return View();
        }
        public ActionResult App()
        {
            return PartialView("App");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}