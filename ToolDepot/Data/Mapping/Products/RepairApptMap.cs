using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Data.Mapping.Products
{
    public class RepairApptMap : EntityTypeConfiguration<RepairAppt>
    {
        public RepairApptMap()
        {
            this.ToTable("RepairAppt");
            this.HasKey(l => l.Id);
            this.Property(l => l.CompanyName).IsRequired();
            this.Property(l => l.Name).IsRequired();
            Property(l => l.PhoneNumber);
            this.Property(l => l.ScheduledTime);
            this.Property(l => l.RepairDescription).IsRequired();
            this.Property(l => l.CreatedDate);
            
        }
    }
}