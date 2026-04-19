using Microsoft.AspNetCore.Mvc;
using SessionLoginApp2.DTOs;
using SessionLoginApp2.Filters;

namespace SessionLoginApp2.Controllers
{
    public class HomeController : Controller
    {
        [SessionAuthorize]
        public IActionResult Dashboard()
        {
            var userDto = new UserDTO
            {
                Name = HttpContext.Session.GetString("UserName"),
                Email = HttpContext.Session.GetString("UserEmail")
            };

            return View(userDto);
        }
    }
}
