using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain;
using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public class UnderConstructionService : CrudService<UnderConstruction>, IUnderConstructionService
    {
        public UnderConstructionService(IRepository<UnderConstruction> repo)
            : base(repo)
        {
            
        }
    }
}