using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Areas.Admin.Models;
using ToolDepot.Areas.Admin.Models.Products;
using ToolDepot.Areas.Admin.Models.UploadImages;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Filters;
using ToolDepot.Helpers;
using ToolDepot.Mappers;
using ToolDepot.Models.Products;
using ToolDepot.Services;
using ToolDepot.Services.Products;

namespace ToolDepot.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class ProductController : Controller
    {
        //
        // GET: /Admin/Product/
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly IProductSpecsService _productSpecsService;
        private readonly IProductFeaturesService _productFeaturesService;
        private readonly IBrochureService _brochureService;
        private readonly IProductReviewService _reviewService;

        public ProductController(IProductCategoryService productCategoryService, IProductService productService, IProductSpecsService productSpecsService, IProductFeaturesService productFeaturesService, IBrochureService brochureService, IProductReviewService reviewService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _productSpecsService = productSpecsService;
            _productFeaturesService = productFeaturesService;
            _brochureService = brochureService;
            _reviewService = reviewService;
        }

        public ActionResult Index()
        {
            var model = new AllProductsListModel
                            {
                                Products = _productService.GetAll().ToList(),
                                AllCategories = _productCategoryService.GetAll().ToList()
                            };

            return View(model);
        }
        #region Product

        //
        // GET: /Admin/Product/Details/5

        public ActionResult Details(int id = 0)
        {
            var model = new ProductDetailModel { Product = _productService.GetById(id) };
            return View(model);
        }

        //
        // GET: /Admin/Product/Create

        public ActionResult Create()
        {
            var model = new CreateProductModel();
            model.AllCategories = _productCategoryService.GetProductCategorySelectList(model.CategoryName, GlobalHelper.SelectListDefaultOption);
            return View(model);
        }

        //
        // POST: /Admin/Product/Create

        [HttpPost]
        public ActionResult Create(CreateProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = model.ToEntity();
                    _productService.Add(entity);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var product = _productService.GetById(id);
            var model = new EditProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                IsFeatured = product.IsFeatured,
                CategoryId = product.CategoryId,
                Product = product,
                ProductSpecs = product.ProductSpecs.ToList(),
                ProductFeatures = product.ProductFeatures.ToList()

            };

            model.AllCategories = _productCategoryService.GetProductCategorySelectList(model.CategoryName, GlobalHelper.SelectListDefaultOption);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(EditProductModel model)
        {
            var product = _productService.GetById(model.Id);
            product.Name = model.Name;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.IsFeatured = model.IsFeatured;
            product.Image = model.Image;
            product.CreatedDate = DateTime.UtcNow;

            _productService.Update(product);

            return RedirectToAction("Edit", "Product", new { id = model.Id });
        }

        [HttpPost]
        public ActionResult EditSpecs(EditProductModel model)
        {
            var specs = _productSpecsService.GetMany(x => x.ProductId == model.Id).ToList();
            if (specs.Any())
            {
                for (int i = 0; i < model.ProductSpecs.Count; i++)
                {
                    if (specs[i] != null)
                    {
                        if (specs[i].Id == model.ProductSpecs[i].Id)
                        {
                            specs[i].SpecType = model.ProductSpecs[i].SpecType;
                            specs[i].SpecName = model.ProductSpecs[i].SpecName;
                            _productSpecsService.Update(specs[i]);
                        }
                    }
                    else
                    {
                        _productSpecsService.Add(model.ProductSpecs[i]);
                    }
                }
            }
            else
            {
                foreach (var spec in model.ProductSpecs)
                {
                    if (!string.IsNullOrEmpty(spec.SpecName))
                    {
                        spec.ProductId = model.Id;
                        _productSpecsService.Add(spec);
                    }
                }
            }
            return RedirectToAction("Edit", "Product", new { id = model.Id });
        }
        [HttpPost]
        public ActionResult EditFeatured(EditProductModel model)
        {
            var features = _productFeaturesService.GetMany(x => x.ProductId == model.Id).ToList();
            if (features.Any())
            {
                foreach (var feature in features)
                {
                    _productFeaturesService.Delete(feature);
                }
                foreach (var feature in model.ProductFeatures)
                {
                    if (feature.ProductId == 0) feature.ProductId = model.Id;
                    _productFeaturesService.Add(feature);
                }
            }
            else
            {
                foreach (var feature in model.ProductFeatures)
                {
                    feature.ProductId = model.Id;
                    _productFeaturesService.Add(feature);
                }
            }
            return RedirectToAction("Edit", "Product", new { id = model.Id });
        }
        #endregion

        #region Category
        public ActionResult CreateCategory()
        {
            var model = new CreateCategoryModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult CreateCategory(CreateCategoryModel model)
        {
            var entity = model.ToEntity();
            _productCategoryService.Add(entity);
            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int id = 0)
        {
            var model = new CreateCategoryModel();
            model = _productCategoryService.GetById(id).ToModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult EditCategory(CreateCategoryModel model)
        {
            var entity = _productCategoryService.GetById(model.Id);
            entity.CategoryName = model.CategoryName;
            entity.CategoryImage = model.CategoryImage;
            entity.CreatedDate = model.CreatedDate;
            entity.IsFeaturedCategory = model.IsFeatured;

            _productCategoryService.Update(entity);

            return View(model);
        }

        #endregion

        public ActionResult ManageBrochure()
        {
            var model = new BrochureModel
                            {
                                Brochures = _brochureService.GetAll().ToList(),
                                Photo = new UploadImageModel()
                            };
            return View(model);
        }

        public ActionResult ApproveReviews()
        {
            var model = new ApproveReviewModel { Reviews = _reviewService.GetAll().ToList() };
            return View(model);
        }

        public ActionResult ViewSingleReview(int id=0)
        {
            var model = new ViewReviewModel {Reviews = _reviewService.GetById(id)};
            return View(model);
        }

        [HttpPost]
        public ActionResult ViewSingleReview(ViewReviewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _reviewService.GetById(model.Reviews.Id);
                entity.IsApproved = true;
                _reviewService.Update(entity);
            }
            return RedirectToAction("ApproveReviews");
        }
        
    }


}
