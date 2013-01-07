using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Core.Domain.Customers
{
    public class EmailSubscription : BaseEntity
    {
        public EmailSubscription()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public string EmailAddress { get; set; }
        public bool Subscribed { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}