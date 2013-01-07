using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToolDepot.Models.Common
{
    public class ContactUsModel
    {
        public ContactUsModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        public string Message { get; set; }
        [DisplayName("Contact Number")]
        public string PhoneNumber { get; set; }
        public bool CallBack { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}