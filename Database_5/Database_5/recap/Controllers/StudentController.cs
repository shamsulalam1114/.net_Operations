using recap.EF;
using recap.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace recap.Controllers
{
    public class StudentController : Controller
    {
        ScholarshipDbContext db;
        public StudentController(ScholarshipDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Students.ToList();
            // CGPA scholarship validation in controller
            ViewBag.ScholarshipMap = data.ToDictionary(
                s => s.Id,
                s => s.Cgpa >= 3.75m ? "Eligible" : "Not Eligible"
            );
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = (from s in db.Students where s.Id == id select s).SingleOrDefault();
            // CGPA scholarship validation in controller
            ViewBag.IsEligible = data?.Cgpa >= 3.75m ? "Eligible" : "Not Eligible";
            return View(data);
        }
    }
}
