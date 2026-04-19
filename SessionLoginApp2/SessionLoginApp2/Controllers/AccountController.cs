using Microsoft.AspNetCore.Mvc;
using SessionLoginApp2.DTOs;
using SessionLoginApp2.EF;
using SessionLoginApp2.EF.Tables;

namespace SessionLoginApp2.Controllers
{
    public class AccountController : Controller
    {
        AppDbContext db;

        public AccountController(AppDbContext db)
        {
            this.db = db;
        }

        // ─── REGISTER ───────────────────────────────────────────

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
                Password = dto.Password
            };

            db.Users.Add(user);
            db.SaveChanges();

            TempData["Msg"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        // ─── LOGIN ──────────────────────────────────────────────

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

            // Store in session (Module 8)
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Dashboard", "Home");
        }

        // ─── LOGOUT ─────────────────────────────────────────────

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
