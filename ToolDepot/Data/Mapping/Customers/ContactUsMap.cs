using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Customers;

namespace ToolDepot.Data.Mapping.Customers
{
    public class ContactUsMap : EntityTypeConfiguration<ContactUs>
    {
        public ContactUsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            this.ToTable("ContactUs");
            // Properties
            this.Property(t => t.Name);
            this.Property(t => t.EmailAddress);
            this.Property(t => t.Message);
            this.Property(t => t.PhoneNumber);
            Property(t => t.CallBack);
            Property(t => t.CreatedDate);
        }
    }
}