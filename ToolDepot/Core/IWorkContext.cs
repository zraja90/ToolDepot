using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolDepot.Core.Domain.Customers;

namespace ToolDepot.Core
{
    public interface IWorkContext
    {
        Customer CurrentCustomer { get; set; }
        bool IsLoggedIn { get; }
        string LogoutUrl { get; }
    }
}
