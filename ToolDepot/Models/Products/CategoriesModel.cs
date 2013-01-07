using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models.Products
{
    public class CategoriesModel
    {
        public IList<ProductCategory> Categories { get; set; }
    }
}