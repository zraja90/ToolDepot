using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Data.Mapping.Products
{
    public class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMap()
        {
            this.ToTable("ProductCategory");
            this.Property(t => t.CategoryName);
            this.Property(t => t.IsFeaturedCategory);
            this.Property(t => t.CategoryImage);
            this.Property(t => t.CreatedDate);
        }
    }
}