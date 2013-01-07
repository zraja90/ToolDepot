using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ToolDepot.Areas.Admin.Models.Products
{
    public class CreateCategoryModel
    {
        public CreateCategoryModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Featured Product?")]
        public bool IsFeatured { get; set; }
        [DisplayName("Category Image")]
        public string CategoryImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}