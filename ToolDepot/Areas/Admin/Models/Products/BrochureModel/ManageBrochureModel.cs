using System.Collections.Generic;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Areas.Admin.Models.Products.BrochureModel
{
    public class ManageBrochureModel
    {
        public IList<Brochure> Brochure { get; set; }
    }
}