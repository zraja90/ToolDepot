using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Core;
using ToolDepot.Core.Common;
using ToolDepot.Models;
using ToolDepot.Services.Authentication;
using ToolDepot.Services.CustomerService;
using ToolDepot.Services.Helpers;

namespace ToolDepot.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly IAuthenticationService _authenticationService;
        public CustomerController(ICustomerRegistrationService customerRegistrationService,ICustomerService customerService,IAuthenticationService authenticationService, IWorkContext workContext)
        {
            _customerRegistrationService = customerRegistrationService;
            _customerService = customerService;
            _workContext = workContext;
            _authenticationService = authenticationService;
        }

        //
        // GET: /Customer/
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var model = new LoginModel();
            
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_customerRegistrationService.ValidateCustomer(model.UserName, model.Password))
                {

                    var customer = _customerService.GetCustomerByUserName(model.UserName);

                    if (customer.TimeZoneId == null)
                    {
                        customer.TimeZoneId = DateTime.UtcNow.ToString();
                        _customerService.Update(customer);
                    }

                    //sign in new customer
                    _authenticationService.Login(customer, model.RememberMe);
                    
                    return RedirectToLocal(returnUrl);
                }
            }

           
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            var returnUrl = _workContext.LogoutUrl;
            _authenticationService.Logout();
            CookieHelper.DeleteAllCookies();

            if (!string.IsNullOrEmpty(returnUrl))
            {
                if (!returnUrl.ToLower().Contains("http://"))
                    returnUrl = "http://" + returnUrl;
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        #endregion

    }
}
