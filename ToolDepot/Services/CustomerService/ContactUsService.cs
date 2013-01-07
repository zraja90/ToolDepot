using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Data;

namespace ToolDepot.Services.CustomerService
{
    public class ContactUsService :CrudService<ContactUs>, IContactUsService
    {
        public ContactUsService(IRepository<ContactUs> repo) : base(repo)
        {
        }
    }
}