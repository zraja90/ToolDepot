using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Areas.Admin.Models;
using ToolDepot.Areas.Admin.Models.UploadImages;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models.Products
{
    public class BrochureModel
    {
        public IEnumerable<Brochure> Brochures { get; set; }
        
    }
}