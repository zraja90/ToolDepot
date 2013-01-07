using System.Web.Mvc;
using ToolDepot.Core;
using ToolDepot.Mappers;
using ToolDepot.Models.Common;
using ToolDepot.Services.CustomerService;

namespace ToolDepot.Controllers
{
    public class CommonController : Controller
    {
        private readonly IWorkContext _workContext;
        private readonly IEmailSubscriptionService _emailSubscriptionService;
        public CommonController(IWorkContext workContext,IEmailSubscriptionService emailSubscriptionService)
        {
            _workContext = workContext;
            _emailSubscriptionService = emailSubscriptionService;
        }

        [ChildActionOnly]
        public ActionResult SubscriptionModule()
        {
            var model = new SubscriptionModel();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult SubscriptionModule(SubscriptionModel model)
        {
            if (ModelState.IsValid)
            {
                model.Subscribed = true;
                var entity = model.ToEntity();
                _emailSubscriptionService.Add(entity);
                model.EmailAddress = "";
            }
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var model = new HeaderModel();
            model.IsLoggedIn = _workContext.IsLoggedIn;
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

    }

    
}
