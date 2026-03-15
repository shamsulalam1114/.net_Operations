using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourAppNamespace.Models;

namespace YourAppNamespace.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public Product? Product { get; set; }

        public IActionResult OnGet(int id)
        {
            // Simulate fetching from database
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1500.00m, Category = "Electronics" },
                new Product { Id = 2, Name = "Mouse", Price = 25.00m, Category = "Electronics" },
                new Product { Id = 3, Name = "Keyboard", Price = 75.00m, Category = "Electronics" },
                new Product { Id = 4, Name = "Monitor", Price = 1200.00m, Category = "Electronics" },
                new Product { Id = 5, Name = "Desk Chair", Price = 350.00m, Category = "Furniture" },
                new Product { Id = 6, Name = "Smartphone", Price = 999.00m, Category = "Electronics" }
            };

            Product = products.FirstOrDefault(p => p.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}