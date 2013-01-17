using System;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Core.Domain;
using ToolDepot.Filters.Helpers;
using ToolDepot.Helpers;
using ToolDepot.Mappers;
using ToolDepot.Models;
using ToolDepot.Models.Common;
using ToolDepot.Models.Products;
using ToolDepot.Services;
using ToolDepot.Services.CustomerService;
using ToolDepot.Services.Email;
using ToolDepot.Services.Products;

namespace ToolDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnderConstructionService _underConstructionService;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IBrochureService _brochureService;
        private readonly IContactUsService _contactUsService;
        private readonly IWorkflowMessageService _workflowMessageService;

        public HomeController(IUnderConstructionService underConstructionService,
           IProductService productService, IProductCategoryService productCategoryService, IBrochureService brochureService, IContactUsService contactUsService,
            IWorkflowMessageService workflowMessageService)
        {
            _underConstructionService = underConstructionService;
            _productService = productService;
            _productCategoryService = productCategoryService;
            _brochureService = brochureService;
            _contactUsService = contactUsService;
            _workflowMessageService = workflowMessageService;
        }
        public ActionResult Index()
        {
            //var model = new BrochureModel { Brochures = _brochureService.GetAll().ToList() };
            return View();
        }

        [ChildActionOnly]
        public ActionResult ProductCategories()
        {
            //return RedirectToAction("Index");
            var categories = new CategoriesModel { Categories = _productCategoryService.GetAll().OrderByDescending(x => x.Products.Count).ToList() };

            return PartialView(categories);
        }

        [ChildActionOnly]
        public ActionResult FeaturedProductCategory()
        {
            var model = new FeaturedCategoriesModel();
            model.FeaturedCategory = _productCategoryService.GetMany(x => x.IsFeaturedCategory).ToList();

            return PartialView(model);
        }

        public ActionResult UnderConstruction()
        {
            return RedirectToAction("Index");
            /*var model = new UnderConstructionModel();

            model.Brochure = _brochureService.GetAll();
            return View(model);*/
        }

        [HttpPost]
        public ActionResult UnderConstruction(UnderConstruction model)
        {
            return RedirectToAction("Index");
            /*if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.EmailAddress))
                {
                    _underConstructionService.Add(model);
                    this.SuccessNotification("Thank You for Subscribing. You will receive an email with updates very soon.");
                }
                else
                {
                    this.ErrorNotification("The email address entered is invalid");
                }
            }

            return View();*/
        }
        public ActionResult Contact()
        {
            var model = new ContactUsModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = model.ToEntity();
                    _contactUsService.Add(entity);
                    _workflowMessageService.SendContactEmail(model.EmailAddress, model.Name, model.Message);
                    this.SuccessNotification("Thank you for contacting us. We will respond withing 24-48 hours.");
                    model = new ContactUsModel();
                }
                catch (Exception)
                {
                    this.ErrorNotification(GlobalHelper.DefaultFormSubmissionErrorMessage);
                    throw;
                }
            }
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
