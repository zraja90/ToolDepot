using System;
using System.Collections.Generic;

namespace ToolDepot.Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        private ICollection<CustomerRole> _customerRoles;
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Avatar { get; set; }
        public string TimeZoneId { get; set; }

        public string ConfirmationToken { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        
        

        public string LastIpAddress { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime LastActivityDateUtc { get; set; }


        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRoles ?? (_customerRoles = new List<CustomerRole>()); }
            protected set { _customerRoles = value; }
        }
    }
}
