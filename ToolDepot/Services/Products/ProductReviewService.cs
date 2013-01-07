using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class ProductReviewService : CrudService<ProductReviews>, IProductReviewService
    {
        public ProductReviewService(IRepository<ProductReviews> repo) : base(repo)
        {
        }
    }
}