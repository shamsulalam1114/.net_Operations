using Microsoft.AspNetCore.Mvc;
using SessionLoginApp.DTOs;
using SessionLoginApp.Filters;

namespace SessionLoginApp.Controllers
{
    public class HomeController : Controller
    {
        [SessionAuthorize] // Module 10 custom filter — must be logged in
        public IActionResult Dashboard()
        {
            // Read session data and map to DTO for the view (Module 9)
            var userDto = new UserDTO
            {
                Name = HttpContext.Session.GetString("UserName"),
                Email = HttpContext.Session.GetString("UserEmail")
            };

            return View(userDto);
        }
    }
}
