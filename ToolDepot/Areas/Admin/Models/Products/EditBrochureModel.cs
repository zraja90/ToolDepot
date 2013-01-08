using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Areas.Admin.Models.Products
{
    public class EditBrochureModel
    {
        public EditBrochureModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Ordinal { get; set; }
        public bool IsActive { get; set; }
        public string ProductImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}