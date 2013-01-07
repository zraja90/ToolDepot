using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models.Products
{
    public class ProductModel
    {
        public Product Product { get; set; }
        public double OverallRating { get; set; }
        public int OverallRecommend { get; set; }
        public int TotalReviews { get; set; }
        public string RecommendPercentage { get; set; }
    }
}