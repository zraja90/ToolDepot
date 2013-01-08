using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToolDepot.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Error(Exception exception)
        {
            return View("Error");

        }

        public ActionResult NotFound()
        {
            //return Content("Not found", "text/plain");
            return View();
        }

        public ActionResult NoAccess()
        {
            //return Content("Forbidden", "text/plain");
            return View();
        }
    }
}
