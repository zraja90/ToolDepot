using ToolDepot.Core.Domain.Customers;

namespace ToolDepot.Services.Authentication
{
    public partial interface IAuthenticationService
    {
        void Login(Customer customer, bool persistentCookie);
        void Logout();
        Customer GetAuthenticatedCustomer();
    }
}
