using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Data.Mapping.Products
{
    public class ProductFeaturesMap : EntityTypeConfiguration<ProductFeatures>
    {
        public ProductFeaturesMap()
        {
            this.ToTable("ProductFeatures");
            this.Property(t => t.Feature);

            HasRequired(t => t.Product)
                .WithMany(p => p.ProductFeatures)
                .HasForeignKey(t => t.ProductId);
        }
    }
}