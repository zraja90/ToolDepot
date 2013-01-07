using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class RepairApptService : CrudService<RepairAppt>, IRepairApptService
    {
        public RepairApptService(IRepository<RepairAppt> repo) : base(repo)
        {
        }
    }
}