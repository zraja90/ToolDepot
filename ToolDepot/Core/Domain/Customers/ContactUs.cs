using System;

namespace ToolDepot.Core.Domain.Customers
{
    public class ContactUs : BaseEntity
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public bool CallBack { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}