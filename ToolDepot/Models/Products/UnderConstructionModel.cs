using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models.Products
{
    public class UnderConstructionModel
    {
        public UnderConstruction UnderConstruction { get; set; }
        public IEnumerable<Brochure> Brochure { get; set; }
    }
}