using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ToolDepot.Core.Domain.Products;


namespace ToolDepot.Data.Mapping.Products
{
    public class BrochureMap : EntityTypeConfiguration<Brochure>
    {
        public BrochureMap()
        {
            this.ToTable("Brochure");
            this.HasKey(l => l.Id);
            this.Property(l => l.ProductName).IsRequired();
            this.Property(l => l.ProductDescription).IsRequired();
            this.Property(l => l.Ordinal);
            this.Property(l => l.IsActive);
            this.Property(l => l.CreatedDate);
            this.Property(l => l.ProductImage);

        }
    }
}