using Microsoft.AspNetCore.Mvc;
using SessionLoginAuthMix.DTOs;
using SessionLoginAuthMix.Filters;

namespace SessionLoginAuthMix.Controllers
{
    public class StudentController : Controller
    {
        [StudentAuthorize]
        public IActionResult Dashboard()
        {
            var userDto = new UserDTO
            {
                Name = HttpContext.Session.GetString("UserName") ?? string.Empty,
                Email = HttpContext.Session.GetString("UserEmail") ?? string.Empty,
                Role = HttpContext.Session.GetString("UserRole") ?? string.Empty
            };

            return View(userDto);
        }
    }
}
