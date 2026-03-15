using Database_5.EF;
using Database_5.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Database_5.Controllers
{
    public class BookController : Controller
    {
        BookStoreDbContext db;

        public BookController(BookStoreDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Books.Include(b => b.Author).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(db.Authors, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            TempData["Msg"] = book.Name + " Created Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = db.Books.Include(b => b.Author).SingleOrDefault(b => b.Id == id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Books.SingleOrDefault(b => b.Id == id);
            ViewBag.Authors = new SelectList(db.Authors, "Id", "Name", data?.AuthorId);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            db.Books.Update(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = db.Books.Include(b => b.Author).SingleOrDefault(b => b.Id == id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = db.Books.SingleOrDefault(b => b.Id == id);
            if (data != null)
            {
                db.Books.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
