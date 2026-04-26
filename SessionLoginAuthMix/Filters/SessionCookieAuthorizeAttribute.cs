using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SessionLoginAuthMix.Filters
{
    public class SessionCookieAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var email = context.HttpContext.Session.GetString("UserEmail");
            var cookieEmail = context.HttpContext.Request.Cookies["UserEmail"];

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(cookieEmail) || email != cookieEmail)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
