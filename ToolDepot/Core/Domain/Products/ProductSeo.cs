using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Core.Domain.Products
{
    public class ProductSeo : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }
}