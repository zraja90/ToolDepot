using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Areas.Admin.Models.Products
{
    public class EditProductModel
    {
        public EditProductModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
        [Required]
        public string Name { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public bool IsFeatured { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public SelectList AllCategories { get; set; }

        public int Id { get; set; }


        public Product Product { get; set; }
        public IList<ProductSpecs> ProductSpecs { get; set; }
        public IList<ProductFeatures> ProductFeatures { get; set; } 
        //SEo
    }
}