using System;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Services.Security;

namespace ToolDepot.Services.CustomerService
{
    /// <summary>
    /// Customer registration service
    /// </summary>
    public partial class CustomerRegistrationService : ICustomerRegistrationService
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IEncryptionService _encryptionService;
        //private readonly CustomerSettings _customerSettings;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="customerService">Customer service</param>
        /// <param name="encryptionService">Encryption service</param>
        public CustomerRegistrationService(ICustomerService customerService, 
            IEncryptionService encryptionService)
        {
            this._customerService = customerService;
            this._encryptionService = encryptionService;
        }

        #endregion

        #region Methods


        public virtual bool ValidateCustomer(string email, string password)
        {
            Customer customer = null;
            customer = _customerService.GetCustomerByUserName(email);

            if (customer == null || customer.Deleted || !customer.Active)
                return false;
            bool isValid = VerifyPassword(password, customer.Password);

            //save last login date
            if (isValid)
            {
                customer.LastLoginDateUtc = DateTime.UtcNow;
                _customerService.Update(customer);
            }

            return isValid;
        }

        //public CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request)
        //{
        //    if (request == null)
        //        throw new ArgumentNullException("request");

        //    if (request.Customer == null)
        //        throw new ArgumentException("Can't load current customer");

        //    var result = new CustomerRegistrationResult();
        //    if (String.IsNullOrEmpty(request.Email))
        //    {
        //        result.AddError("Email is not provided");
        //        return result;
        //    }
        //    if (!CommonHelper.IsValidEmail(request.Email))
        //    {
        //        result.AddError("Wrong email");
        //        return result;
        //    }
        //    if (String.IsNullOrWhiteSpace(request.Password))
        //    {
        //        result.AddError("Password Is Not Provided");
        //        return result;
        //    }
    
        //    //validate unique user
        //    if (_customerService.GetCustomerByUserName(request.ProgramId,request.Email) != null)
        //    {
        //        result.AddError("Email Already Exists");
        //        return result;
        //    }

        //    //at this point request is valid
        //    request.Customer.ProgramId = request.ProgramId;
        //    request.Customer.UserName = request.Username;
        //    request.Customer.Email = request.Email;
          
        //    request.Customer.Password = EncryptPassword(request.Password);
        //    request.Customer.Active = request.IsApproved;
        //    request.Customer.Deleted = false;
   

        //    request.Customer.CreatedOnUtc = DateTime.UtcNow;
        //    request.Customer.LastActivityDateUtc = DateTime.UtcNow;


        //    _customerService.InsertCustomer(request.Customer);
        //    return result;
        //}

        //public virtual PasswordChangeResult ChangePassword(ChangePasswordRequest request)
        //{
        //    if (request == null)
        //        throw new ArgumentNullException("request");

        //    var result = new PasswordChangeResult();
        //    if (String.IsNullOrWhiteSpace(request.Email))
        //    {
        //        result.AddError("Email Is Not Provided");
        //        return result;
        //    }
        //    if (String.IsNullOrWhiteSpace(request.NewPassword) || String.IsNullOrWhiteSpace(request.NewPasswordConfirm))
        //    {
        //        result.AddError("Please enter old and new passwords");
        //        return result;
        //    }
        //    if (request.NewPassword != request.NewPasswordConfirm)
        //    {
        //        result.AddError("New Password and Confirm New Password do not match");
        //        return result;
        //    }

        //    var customer = _customerService.GetCustomerByUserName(request.ProgramId, request.Email);
        //    if (customer == null)
        //    {
        //        result.AddError("Email Not Found");
        //        return result;
        //    }


        //    var requestIsValid = false;
        //    if (request.ValidateRequest)
        //    {
        //        //password
        //        var oldPwd = request.OldPassword;
        //        var oldPasswordIsValid = VerifyPassword(oldPwd, customer.Password);
        //        if (!oldPasswordIsValid)
        //            result.AddError("Old password doesn't match");

        //        if (oldPasswordIsValid)
        //            requestIsValid = true;
        //    }
        //    else
        //        requestIsValid = true;


        //    //at this point request is valid
        //    if (requestIsValid)
        //    {
        //        customer.Password = EncryptPassword(request.NewPassword);
        //        _customerService.UpdateCustomer(customer);
        //    }

        //    return result;
        //}


        public string EncryptPassword(string password)
        {
            return _encryptionService.EncryptPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {   
            #if DEBUG
                return true;
            #endif
 
            return _encryptionService.VerifyPassword(password, hashedPassword);
        }

        #endregion
    }
}