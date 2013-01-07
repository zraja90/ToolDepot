using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Core.Domain.Products
{
    public class Product : BaseEntity
    {
        public Product()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsFeatured { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; }

        private ICollection<ProductSpecs> _productSpecs;
        public virtual ICollection<ProductSpecs> ProductSpecs 
        { get { return _productSpecs ?? (_productSpecs = new List<ProductSpecs>()); }
            protected set { _productSpecs = value; }
        }

        private ICollection<ProductFeatures> _productFeatures;
        public virtual ICollection<ProductFeatures> ProductFeatures
        {
            get { return _productFeatures ?? (_productFeatures = new List<ProductFeatures>()); }
        }

        private ICollection<ProductReviews> _productReviews;
        public virtual ICollection<ProductReviews> ProductReviews  {
            get { return _productReviews ?? (_productReviews = new List<ProductReviews>()); }
        }

        //Incudes
        //Manuals

    }

    


}