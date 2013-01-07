using ToolDepot.Core.Domain.Customers;
using ToolDepot.Data;

namespace ToolDepot.Services.CustomerService
{
    /// <summary>
    /// Customer service
    /// </summary>
    public partial class CustomerService : CrudService<Customer>, ICustomerService
    {
        #region Ctor

        private readonly IRepository<Customer> _customerRepository; 
        public CustomerService(IRepository<Customer> customerRepository)
            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        public Customer GetCustomerByUserName(string email)
        {
            return _customerRepository.Get(x => x.UserName == email);
        }
    }
}