using System;

namespace ToolDepot.Core.Domain.Products
{
    public class RequestAQuote : BaseEntity
    {
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}