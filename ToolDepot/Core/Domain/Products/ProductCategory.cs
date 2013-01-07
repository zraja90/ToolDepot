using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Core.Domain.Products
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsFeaturedCategory { get; set; }
        public string CategoryImage { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public virtual ICollection<Product> Products { get;set; }
        

    }
}