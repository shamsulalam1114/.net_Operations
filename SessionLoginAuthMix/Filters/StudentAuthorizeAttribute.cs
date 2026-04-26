using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SessionLoginAuthMix.Filters
{
    public class StudentAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionRole = context.HttpContext.Session.GetString("UserRole");
            var cookieRole = context.HttpContext.Request.Cookies["UserRole"];
            var sessionEmail = context.HttpContext.Session.GetString("UserEmail");
            var cookieEmail = context.HttpContext.Request.Cookies["UserEmail"];

            if (string.IsNullOrEmpty(sessionEmail) || string.IsNullOrEmpty(cookieEmail) ||
                string.IsNullOrEmpty(sessionRole) || string.IsNullOrEmpty(cookieRole) ||
                sessionEmail != cookieEmail || sessionRole != cookieRole || sessionRole != "Student")
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
