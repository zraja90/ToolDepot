namespace ToolDepot.Services.CustomerService
{
    /// <summary>
    /// Customer registration interface
    /// </summary>
    public partial interface ICustomerRegistrationService
    {
        bool ValidateCustomer(string email, string password);

        //CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request);

        //PasswordChangeResult ChangePassword(ChangePasswordRequest request);

        string EncryptPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}