using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Areas.Admin.Models.Products
{
    public class ApproveReviewModel
    {
        public IList<ProductReviews> Reviews { get; set; }
    }
}