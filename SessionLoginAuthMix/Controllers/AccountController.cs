using Microsoft.AspNetCore.Mvc;
using SessionLoginAuthMix.DTOs;
using SessionLoginAuthMix.EF;
using SessionLoginAuthMix.EF.Tables;

namespace SessionLoginAuthMix.Controllers
{
    public class AccountController : Controller
    {
        AppDbContext db;

        public AccountController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            if (dto.Role != "Student" && dto.Role != "Teacher")
            {
                ModelState.AddModelError("Role", "Select a valid role.");
                return View(dto);
            }

            bool emailExists = db.Users.Any(u => u.Email == dto.Email);
            if (emailExists)
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View(dto);
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };

            db.Users.Add(user);
            db.SaveChanges();

            TempData["Msg"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var user = (from u in db.Users
                        where u.Email == dto.Email && u.Password == dto.Password
                        select u).SingleOrDefault();

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(dto);
            }

            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetInt32("UserId", user.Id);

            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddMinutes(30)
            };
            Response.Cookies.Append("UserEmail", user.Email, cookieOption);
            Response.Cookies.Append("UserRole", user.Role, cookieOption);

            if (user.Role == "Student")
            {
                return RedirectToAction("Dashboard", "Student");
            }
            return RedirectToAction("Dashboard", "Teacher");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("UserEmail");
            Response.Cookies.Delete("UserRole");
            return RedirectToAction("Login");
        }
    }
}
