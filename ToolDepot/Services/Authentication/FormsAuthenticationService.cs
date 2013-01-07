using System;
using System.Web;
using System.Web.Security;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Services.CustomerService;

namespace ToolDepot.Services.Authentication
{
    public partial class FormsAuthenticationService : IAuthenticationService
    {

        private readonly HttpContextBase _httpContext;
        private readonly ICustomerService _customerService;
        private readonly TimeSpan _expirationTimeSpan;

        private Customer _cachedCustomer;

        public FormsAuthenticationService(HttpContextBase httpContext,
            ICustomerService customerService)
        {
            this._httpContext = httpContext;
            this._customerService = customerService;
            this._expirationTimeSpan = FormsAuthentication.Timeout;
        }

        public void Login(Customer customer, bool persistentCookie)
        {
            FormsAuthentication.SetAuthCookie(customer.Id.ToString(), persistentCookie);
        }


        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public Customer GetAuthenticatedCustomer()
        {
            if (_cachedCustomer != null)
                return _cachedCustomer;

            if (_httpContext == null ||
                _httpContext.Request == null ||
                !_httpContext.Request.IsAuthenticated ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            //var userName = _httpContext.User.Identity.Name;
            //var user = _userService.GetUserByEmail(userName);
            var customerId = _httpContext.User.Identity.Name;
            var customer = _customerService.GetById(Convert.ToInt32(customerId));


            if (customer != null && customer.Active && !customer.Deleted)
                _cachedCustomer = customer;
            return _cachedCustomer;
        }
    }
}
