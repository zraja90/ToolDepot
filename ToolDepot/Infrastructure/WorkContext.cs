using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Services.Authentication;
using ToolDepot.Services.CustomerService;

namespace ToolDepot.Infrastructure
{
    public class WorkContext : IWorkContext
    {
        private readonly HttpContextBase _httpContext;
        private readonly ICustomerService _customerService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IWebHelper _webHelper;
        private Customer _cachedCustomer;
        

        public WorkContext(HttpContextBase httpContext,
                             ICustomerService customerService,
                             IAuthenticationService authenticationService,
                             IWebHelper webHelper
                              )
        {
            this._httpContext = httpContext;
            this._customerService = customerService;
            this._authenticationService = authenticationService;
            this._webHelper = webHelper;
        }
        private bool IsAuthenticated
        {
            get { return _httpContext.Request.IsAuthenticated; }
        }
        protected Customer GetCurrentCustomer()
        {

            if (_cachedCustomer != null)
                return _cachedCustomer;

            if (!IsAuthenticated)
                return null;

            Customer customer = null;
            if (_httpContext != null)
            {

                customer = _authenticationService.GetAuthenticatedCustomer();

            }

            //validation
            if (customer != null && !customer.Deleted && customer.Active)
            {
                //update last activity date
                if (customer.LastActivityDateUtc.AddMinutes(1.0) < DateTime.UtcNow)
                {
                    customer.LastActivityDateUtc = DateTime.UtcNow;
                    _customerService.Update(customer);
                }

                //update IP address
                string currentIpAddress = _webHelper.GetCurrentIpAddress();
                if (!String.IsNullOrEmpty(currentIpAddress))
                {
                    if (!currentIpAddress.Equals(customer.LastIpAddress))
                    {
                        customer.LastIpAddress = currentIpAddress;
                        _customerService.Update(customer);
                    }
                }

                _cachedCustomer = customer;
            }

            return _cachedCustomer;
        }
        public Customer CurrentCustomer
        {
            get
            {
                return GetCurrentCustomer();
            }
            set
            {
                _cachedCustomer = value;
            }
        }
        public bool IsLoggedIn
        {
            get { return IsAuthenticated; }

        }

        public string LogoutUrl
        {
            get { return "http://localhost:65403/"; }
        }

    }
}