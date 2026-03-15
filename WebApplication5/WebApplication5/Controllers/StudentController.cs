using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Profile(int Id)
        {
            var student = new Models.Student
            {
                Id = Id,
                Name = "John Doe",
                Description = "A student at XYZ University."
            };
            return View(student);
        }
    }
}
