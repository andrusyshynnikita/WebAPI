using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.WebApp.EF;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        TaskContext db = new TaskContext();

        public ActionResult Index()
        {
            var a = View(db.Tasks);

            return View(db.Tasks);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
