using System;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Filters.Helpers;
using ToolDepot.Helpers;
using ToolDepot.Mappers;
using ToolDepot.Models.Products;
using ToolDepot.Services.Email;
using ToolDepot.Services.Products;

namespace ToolDepot.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IRepairApptService _repairApptService;
        private readonly IProductReviewService _productReviewService;
        private readonly IBrochureService _brochureService;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IRequestQuoteService _requestAQuoteService;
        public ProductsController(IProductService productService, IProductCategoryService productCategoryService,
            IBrochureService brochureService, IWorkflowMessageService workflowMessageService,
            IRequestQuoteService requestAQuoteService, IRepairApptService repairApptService, IProductReviewService productReviewService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _brochureService = brochureService;
            _workflowMessageService = workflowMessageService;
            _requestAQuoteService = requestAQuoteService;
            _repairApptService = repairApptService;
            _productReviewService = productReviewService;
        }
        //
        // GET: /Products/

        public ActionResult Index(int id = 0)
        {

            return View();
        }

        public ActionResult AllCategories()
        {
            var model = new CategoriesModel { Categories = _productCategoryService.GetAll().ToList() };
            return View(model);
        }

        public ActionResult Category(int id = 0)
        {
            var model = new CategoryWithProductsModel { Category = _productCategoryService.GetById(id) };
            return View(model);
        }

        public ActionResult RequestAQuote(string id = "0")
        {
            var model = new RequestQuoteModel
                            {
                                ProductId = id,
                                AllProducts = _productService.GetAllProductsSelectList(id, GlobalHelper.SelectListDefaultOption)
                            };
            return View(model);
        }
        [HttpPost]
        public ActionResult RequestAQuote(RequestQuoteModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = model.ToEntity();
                    _requestAQuoteService.Add(entity);
                    model.AllProducts = _productService.GetAllProductsSelectList(model.ProductId, GlobalHelper.SelectListDefaultOption);
                    this.SuccessNotification("We have receieved your request. We will respond withing 24-48 hours.");
                }
                catch (Exception)
                {
                    this.ErrorNotification("An error has occurred while submitting your request. Please check your form fields and submit again.");
                }


            }
            return View(model);
        }

        public ActionResult Product(int id = 0)
        {
            var model = new ProductModel { Product = _productService.GetById(id) };
            double count = 0;
            int totalCount = 0;
            var recommendCount = 0;

            if (model.Product.ProductReviews.Count > 0)
            {
                foreach (var review in model.Product.ProductReviews)
                {
                    if (review.IsApproved == EnumApproveReview.Approved.ToString())
                    {
                        totalCount++;
                        count += review.Rating;
                        if (review.Recommend)
                        {
                            recommendCount++;
                        }
                    }
                }
            }
            model.TotalReviews = totalCount;

            var recommendPercentage = string.Empty;
            if (totalCount > 0)
            {
                recommendPercentage = string.Format("{0:P0}", recommendCount / totalCount);
            }
            
            model.OverallRecommend = recommendCount;
            model.OverallRating = count / model.Product.ProductReviews.Count(x => x.IsApproved==EnumApproveReview.Approved.ToString());;
            model.RecommendPercentage = recommendPercentage;
            return View(model);
        }

        public ActionResult Featured()
        {
            var model = new BrochureModel
                            {
                                Brochures = _brochureService.GetAll().OrderBy(x=>x.Ordinal).ToList()
                            };
            return View(model);
        }

        public ActionResult RepairServices()
        {

            return View();
        }

        public ActionResult RepairAppt()
        {
            var model = new RepairApptModel { Dates = TimeRange.GetFutureDates(), Times = TimeRange.GetWorkHours() };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult RepairAppt(RepairApptModel model)
        {
            if (ModelState.IsValid)
            {
                model.ScheduledTime = DateTime.Parse(model.ScheduledDate + " " + model.ScheduledTimes);

                var entity = model.ToEntity();
                //entity.ScheduledTime = scheduledDate;
                _repairApptService.Add(entity);

            }
            model.Dates = TimeRange.GetFutureDates();
            model.Times = TimeRange.GetWorkHours();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Review(int id)
        {
            var model = new ProductReviewModel
                            {
                                Product = _productService.GetById(id),
                                ProductId = id
                            };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Review(ProductReviewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetById(model.ProductId);
                model.Product = product;
                try
                {
                    var review =
                        _productReviewService.Get(x => model.ProductId == x.ProductId && (x.EmailAddress == model.EmailAddress || x.UserName == model.UserName));
                    if (review == null)
                    {
                        var entity = model.ToEntity();
                        _productReviewService.Add(entity);
                        this.SuccessNotification("Thank you for your review. We will email you once it has been approved.");
                    }
                    else
                    {
                        this.ErrorNotification(review.EmailAddress == model.EmailAddress
                                                   ? "The email address entered is already in use. Please use another email address"
                                                   : "The username entered is already in use. Please use another username");
                        return PartialView(model);
                    }
                }
                catch (Exception)
                {

                    this.ErrorNotification("An error has occurred while submitting your review. Please try again later.");
                }
            }
            int productId = model.ProductId;
            model = new ProductReviewModel { Product = _productService.GetById(productId) };
            return PartialView(model);
        }
    }
}