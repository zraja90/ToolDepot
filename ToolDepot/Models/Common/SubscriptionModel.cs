using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ToolDepot.Models.Common
{
    public class SubscriptionModel
    {
        public SubscriptionModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        public bool Subscribed { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}