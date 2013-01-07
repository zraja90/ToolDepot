using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Data;

namespace ToolDepot.Services.CustomerService
{
    public class EmailSubscriptionService: CrudService<EmailSubscription>, IEmailSubscriptionService
    {
        public EmailSubscriptionService(IRepository<EmailSubscription> repo) : base(repo)
        {
        }
    }
}