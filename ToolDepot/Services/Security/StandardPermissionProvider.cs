using System.Collections.Generic;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Core.Domain.Security;

namespace ToolDepot.Services.Security
{
    public partial class StandardPermissionProvider : IPermissionProvider
    {
        //admin area permissions
        public static readonly PermissionRecord AccessAdminPanel = new PermissionRecord
        {
            Name = "Access admin area",
            SystemName = "AccessAdminPanel",
            Category = "Standard"
        };
        
        public virtual IEnumerable<PermissionRecord> GetPermissions()
        {
            return new[]
                       {
                            AccessAdminPanel
                       };
        }

        public IEnumerable<DefaultPermissionRecord> GetDefaultPermissions()
        {
            return new[]
                       {
                           new DefaultPermissionRecord
                               {
                                   CustomerRoleSystemName = SystemCustomerRoleNames.Admin,
                                   PermissionRecords = new[]
                                                {
                                                    AccessAdminPanel
                                                }
                               }
                       };
        }
    }
}