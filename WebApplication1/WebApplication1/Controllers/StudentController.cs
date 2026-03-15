using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        
        public IActionResult Profile(int id)
        {
            
            var student = new Student
            {
                Id = id,
                Name = "Md. Shamsul Alam",
                Age = 23,
                Department = "Computer Science And engineering",
                CGPA = 3.8
            };


            
            return View(student);
        }
    }
}