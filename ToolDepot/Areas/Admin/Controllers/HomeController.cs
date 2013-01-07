using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Areas.Admin.Models;
using ToolDepot.Filters;
using ToolDepot.Helpers;

namespace ToolDepot.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

     
        
    }
}
