using System.Web.Mvc;
using ToolDepot.Core;
using ToolDepot.Models.Common;

namespace ToolDepot.Areas.Admin.Controllers
{
    public class CommonController : Controller
    {
        private readonly IWorkContext _workContext;
        public CommonController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        [ChildActionOnly]
        public ActionResult AdminHeader()
        {
            var model = new HeaderModel {IsLoggedIn = _workContext.IsLoggedIn};
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult AdminFooter()
        {
            return PartialView();
        }

    }
}
