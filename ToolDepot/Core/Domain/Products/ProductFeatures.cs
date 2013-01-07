using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Core.Domain.Products
{
    public class ProductFeatures : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Feature { get; set; }
    }
}