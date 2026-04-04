using midterm_prep.EF;
using midterm_prep.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace midterm_prep.Controllers
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {

            db.Students.Add(student);
            db.SaveChanges();
            TempData["Msg"] = student.Name + " Created Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = (from s in db.Students where s.Id == id select s).SingleOrDefault();

            // CGPA scholarship validation in controller
            ViewBag.IsEligible = data?.Cgpa >= 3.75m ? "Eligible" : "Not Eligible";

            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = (from s in db.Students where s.Id == id select s).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = (from s in db.Students where s.Id == id select s).SingleOrDefault();
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = (from s in db.Students where s.Id == id select s).SingleOrDefault();
            if (data != null)
            {
                db.Students.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
