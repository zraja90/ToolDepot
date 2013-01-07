using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models
{
    public class FeaturedProductModel
    {
        public IList<Product> Products { get; set; }
    }
}