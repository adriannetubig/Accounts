using AccountsData;
using AccountsFunction;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountsWebAuthentication.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private IFUser _iFUser;
        private IDUser _iDUser;
        private IDRole _iDRole;
        private IFRole _iFRole;

        private bool AllowAnonymous;
        private string RedirectController;
        private string RedirectMethod;

        public string[] AllowedRoles { get; set; }

        public CustomAuthorizeAttribute()
        {
            _iFUser = new FUser();
        }

        public CustomAuthorizeAttribute(bool allowAnonymous)
        {
            AllowAnonymous = allowAnonymous;
            RedirectController = string.Empty;
            RedirectMethod = string.Empty;
            AllowedRoles = new string[0];
        }

        public CustomAuthorizeAttribute(bool allowAnonymous, string[] allowedRoles)
        {
            AllowAnonymous = allowAnonymous;
            AllowedRoles = allowedRoles;
            RedirectController = string.Empty;
            RedirectMethod = string.Empty;
        }

        public CustomAuthorizeAttribute(bool allowAnonymous, string redirectController, string redirectMethod)
        {
            AllowAnonymous = allowAnonymous;
            RedirectController = redirectController;
            RedirectMethod = redirectMethod;
            AllowedRoles = new string[0];
        }

        public CustomAuthorizeAttribute(bool allowAnonymous, string redirectController, string redirectMethod, string[] allowedRoles)
        {
            AllowAnonymous = allowAnonymous;
            AllowedRoles = allowedRoles;
            RedirectController = redirectController;
            RedirectMethod = redirectMethod;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string currentUserlogged = WindowsUser.Username;
            try
            {
                _iDUser = new DUser();
                _iDRole = new DRole();
                _iFUser = new FUser(_iDUser);
                _iFRole = new FRole(_iDRole);
                return _iFUser.IsMethodAccessible(currentUserlogged, AllowedRoles.ToList());
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}