using Database_4.EF;
using Database_4.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Database_4.Controllers
{
    public class CategoryController : Controller
    {
        ShopDbContext db;

        public CategoryController(ShopDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            TempData["Msg"] = category.Name + " Created Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = (from c in db.Categories where c.Id == id select c).SingleOrDefault();
            return View(data);
        }
    }
}
