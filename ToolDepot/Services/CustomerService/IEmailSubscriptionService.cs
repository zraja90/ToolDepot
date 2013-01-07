using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolDepot.Core.Domain.Customers;

namespace ToolDepot.Services.CustomerService
{
    public interface IEmailSubscriptionService:ICrudService<EmailSubscription>
    {
    }
}
