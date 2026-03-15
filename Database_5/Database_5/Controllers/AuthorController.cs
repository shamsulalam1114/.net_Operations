using Database_5.EF;
using Database_5.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Database_5.Controllers
{
    public class AuthorController : Controller
    {
        BookStoreDbContext db;

        public AuthorController(BookStoreDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Authors.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            TempData["Msg"] = author.Name + " Created Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = (from a in db.Authors where a.Id == id select a).SingleOrDefault();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = (from a in db.Authors where a.Id == id select a).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            db.Authors.Update(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = (from a in db.Authors where a.Id == id select a).SingleOrDefault();
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = (from a in db.Authors where a.Id == id select a).SingleOrDefault();
            if (data != null)
            {
                db.Authors.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
