using ToolDepot.Core.Domain.Customers;

namespace ToolDepot.Services.CustomerService
{
    public partial interface ICustomerService : ICrudService<Customer>
    {
        Customer GetCustomerByUserName(string email);
    }
}