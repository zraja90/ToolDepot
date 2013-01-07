using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Customers;

namespace ToolDepot.Data.Mapping.Customers
{
    public class EmailSubscriptionMap : EntityTypeConfiguration<EmailSubscription>
    {
        public EmailSubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            ToTable("EmailSubscription");
            Property(t => t.EmailAddress);
            Property(t => t.Subscribed);
            Property(t => t.CreatedDate);
        }
    }
}