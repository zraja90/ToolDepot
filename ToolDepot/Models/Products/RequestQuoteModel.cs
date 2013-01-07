using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToolDepot.Models.Products
{
    public class RequestQuoteModel
    {
        public RequestQuoteModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
        [Required]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        
        [DisplayName("Product")]
        public string ProductId { get; set; }
        public SelectList AllProducts { get; set; }
    }
}