using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models.Products
{
    public class ProductReviewModel
    {
        public ProductReviewModel()
        {
            CreatedDate = DateTime.UtcNow;
            IsApproved = false;
        }

        public int ProductId { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string EmailAddress { get; set; }
        public string Location { get; set; }
        
        [Required]
        public double Rating { get; set; }
        
        
        [Required]
        [DisplayName("Review Summary")]
        public string ReviewTitle { get; set; }
        
        [Required]
        [DisplayName("Your Review")]
        public string Review { get; set; }
        
        [DisplayName("Would you recommend this?")]
        public bool Recommend { get; set; }

        public bool IsApproved { get; set; }
        public DateTime CreatedDate { get; set; }

        
        public Product Product { get; set; }
    }
}