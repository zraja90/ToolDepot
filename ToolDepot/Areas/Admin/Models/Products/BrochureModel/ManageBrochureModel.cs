using System;
using System.Collections.Generic;
using System.Linq;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Areas.Admin.Models.Products.BrochureModel
{
    public class ManageBrochureModel
    {
        public IEnumerable<BrochureItem> Brochure { get; set; }
        public string BrochureJson { get; set; }
    }
    public class BrochureItem
    {
        public BrochureItem()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Ordinal { get; set; }
        public bool IsActive { get; set; }
        public string ProductImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}