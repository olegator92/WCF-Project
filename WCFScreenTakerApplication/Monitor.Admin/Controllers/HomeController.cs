using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monitor.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Monitoring Admin";
            var entites = new ScreensDBEntities();
            
            return View(entites.Screens.ToList());
        }


        public ActionResult About()
        {
            return View();
        }
    }
}
