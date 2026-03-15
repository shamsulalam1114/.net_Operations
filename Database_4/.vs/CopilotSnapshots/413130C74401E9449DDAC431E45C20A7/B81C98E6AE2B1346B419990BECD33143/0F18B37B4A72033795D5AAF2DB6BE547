using Database_4.EF;
using Database_4.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Database_4.Controllers
{
    public class ProductController : Controller
    {
        ShopDbContext db;

        public ProductController(ShopDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Products.Include(p => p.CidNavigation).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            TempData["Msg"] = product.Name + " Created Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = (from p in db.Products.Include(p => p.CidNavigation) where p.Id == id select p).SingleOrDefault();
            return View(data);
        }
    }
}
