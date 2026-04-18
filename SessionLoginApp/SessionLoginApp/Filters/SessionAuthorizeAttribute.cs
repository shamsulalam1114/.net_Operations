using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SessionLoginApp.Filters
{
    public class SessionAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if UserEmail exists in session
            var email = context.HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
            {
                // Not logged in → redirect to Login
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
