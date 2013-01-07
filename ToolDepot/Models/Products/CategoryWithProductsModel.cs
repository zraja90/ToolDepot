using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models.Products
{
    public class CategoryWithProductsModel
    {
        public ProductCategory Category { get; set; }
    }
}