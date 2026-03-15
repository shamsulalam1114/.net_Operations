using Database_1.EF;
using Database_1.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Database_1.Controllers
{
    public class StudentController : Controller
    {
        SchoolDbContext db;
        
        public StudentController(SchoolDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            db.Students.Add(student); // query saved not committed
            db.SaveChanges(); // query commit returns no of rows affected
            TempData["Msg"] = student.Name + " Created Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = (from s in db.Students where s.StudentId == id select s).SingleOrDefault();
            return View(data);
            // Alternative: db.Students.Find(id); // Search primary key
        }
    }
}