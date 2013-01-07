using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Helpers;
using ToolDepot.Services;
using ToolDepot.Services.Products;

namespace ToolDepot.Models.Products
{
    public class ProductWithCategoryModel
    {
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        
        public SelectList AllCategory { get; set; }

        public void PopulateSelectList(IProductCategoryService productCategoryService)
        {
            //productCategoryService.GetProductCategorySelectList(Category, GlobalHelper.SelectListDefaultOption);
        }
    }
}