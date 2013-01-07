using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Data.Mapping.Products
{
    public class ProductReviewsMap : EntityTypeConfiguration<ProductReviews>
    {
        public ProductReviewsMap()
        {
            this.ToTable("ProductReviews");
            this.HasKey(l => l.Id);
            this.Property(l => l.ProductId).IsRequired();
            this.Property(l => l.UserName).IsRequired();
            this.Property(l => l.EmailAddress);
            this.Property(l => l.IsApproved);
            this.Property(l => l.CreatedDate);
            this.Property(l => l.Location);
            this.Property(l => l.Recommend);
            this.Property(l => l.Review);
            this.Property(l => l.ReviewTitle);
            this.Property(l => l.Rating);

        }
    }
}