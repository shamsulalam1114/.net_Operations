using Auth.AuthFilters;
using Auth.DTOs;
using Auth.EF;
using Auth.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Controllers
{
    public class AuthController : Controller
    {
        AuthBSp26Context db;

        


        public AuthController(AuthBSp26Context db) { 
            
            this.db = db;
        }
        [Logged]
        public IActionResult Dashboard() {
            //if (HttpContext.Session.GetString("Uname") != null) {
                ViewBag.Uname = HttpContext.Session.GetString("Uname");
                ViewBag.Type = HttpContext.Session.GetInt32("UType");
                return View();
            //}
            //return Unauthorized();
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Uname, string Pass)
        {
            var u = (from user in db.Users
                    where user.Username.Equals(Uname) &&
                    user.Password.Equals(GetMd5(Pass))
                    select user).SingleOrDefault();
            if (u != null) {
                HttpContext.Session.SetString("Uname",u.Username);
                HttpContext.Session.SetInt32("UType",u.Type);
                if (u.Type == 1)
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else if (u.Type == 2)
                {
                    return RedirectToAction("Dashboard", "Student");

                }
                else if (u.Type == 3) {
                    return RedirectToAction("Dashboard","Teacher");
                }
                return RedirectToAction("Dashboard");
            }
            TempData["Class"] = "danger";
            TempData["Msg"] = "Invalid Username and Password";
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View(new RegDTO() { });
        }
        [HttpPost]
        public IActionResult Registration(RegDTO obj)
        {
            if (ModelState.IsValid) {
                var user = new User()
                {
                    Name = obj.Name,
                    Email = obj.Email,
                    Username = obj.Username,
                    Password = GetMd5(obj.Password),
                    Type = 2
                };
                db.Users.Add(user);
                db.SaveChanges();
                TempData["Class"] = "success";
                TempData["Msg"] = "Registration Successfull";
                return RedirectToAction("Login");
            }
            return View(obj);

        }
        static string GetMd5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // lowercase hex
                }

                return sb.ToString();
            }
        }
    }
}
