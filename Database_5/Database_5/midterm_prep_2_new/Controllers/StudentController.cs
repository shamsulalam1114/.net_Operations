using midterm_prep_2_new.EF;
using midterm_prep_2_new.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace midterm_prep_2_new.Controllers
{
    public class StudentController : Controller
    {
        ScholarDbContext db;

        public StudentController(ScholarDbContext db)
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
            db.Students.Add(student);
            db.SaveChanges();
            TempData["Msg"] = student.Name + " Created Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = (from s in db.Students where s.Id == id select s).SingleOrDefault();
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