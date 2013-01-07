using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models
{
    public class FeaturedCategoriesModel
    {
        public IList<ProductCategory> FeaturedCategory { get; set; }
    }
}