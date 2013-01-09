using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Core.Domain.Products
{
    public class ProductReviews : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }

        public double Rating { get; set; }
        public string ReviewTitle { get; set; }
        public string Review { get; set; }
        public bool Recommend { get; set; }

        public string IsApproved { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}