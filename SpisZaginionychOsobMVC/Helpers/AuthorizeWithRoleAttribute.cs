using SpisZaginionychOsobMVC.Enums;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace SpisZaginionychOsobMVC.Helpers
{
    public class AuthorizeWithRoleAttribute : AuthorizeAttribute
    {
        private readonly Roles _role;

        public AuthorizeWithRoleAttribute(Roles role)
        {
            _role = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext) => httpContext.User.HasPermissions(_role);

    }
}