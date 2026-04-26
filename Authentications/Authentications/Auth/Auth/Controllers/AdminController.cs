using Auth.AuthFilters;
using Auth.DTOs;
using Auth.EF;
using Auth.EF.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        AuthBSp26Context db;
        public AdminController(AuthBSp26Context db)
        {
            this.db = db;
        }

        
        public IActionResult Dashboard()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Create() { 
            var types = db.UserTypes.ToList();
            ViewBag.Types = types;  
            return View(new RegDTO() { });  
        }
        
        [HttpPost]
        public IActionResult Create(RegDTO obj) {
            if (ModelState.IsValid) {
                var u = new User { 
                    Name = obj.Name,
                    Email = obj.Email,
                    Password = obj.Password, //md5
                    Username = obj.Username,
                    Type = obj.Type,    
                };
                db.Users.Add(u);    
                db.SaveChanges();
            }
            var types = db.UserTypes.ToList();
            ViewBag.Types = types;
            return View(obj);
        }
    }
}
