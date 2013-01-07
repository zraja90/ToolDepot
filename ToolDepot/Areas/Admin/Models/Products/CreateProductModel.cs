using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Helpers;
using ToolDepot.Services;

namespace ToolDepot.Areas.Admin.Models.Products
{
    
    public class CreateProductModel
    {
        
        public CreateProductModel()
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
    }
}