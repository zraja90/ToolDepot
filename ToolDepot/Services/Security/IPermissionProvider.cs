using System.Collections.Generic;
using ToolDepot.Core.Domain.Security;

namespace ToolDepot.Services.Security
{
    public interface IPermissionProvider
    {
        IEnumerable<PermissionRecord> GetPermissions();
        IEnumerable<DefaultPermissionRecord> GetDefaultPermissions();
    }
}
