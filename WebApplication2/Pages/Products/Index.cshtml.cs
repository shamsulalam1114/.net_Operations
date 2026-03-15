using Microsoft.AspNetCore.Mvc.RazorPages;
using YourAppNamespace.Models;

namespace YourAppNamespace.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            // Create a list of products
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1500.00m, Category = "Electronics" },
                new Product { Id = 2, Name = "Mouse", Price = 25.00m, Category = "Electronics" },
                new Product { Id = 3, Name = "Keyboard", Price = 75.00m, Category = "Electronics" },
                new Product { Id = 4, Name = "Monitor", Price = 1200.00m, Category = "Electronics" },
                new Product { Id = 5, Name = "Desk Chair", Price = 350.00m, Category = "Furniture" },
                new Product { Id = 6, Name = "Smartphone", Price = 999.00m, Category = "Electronics" }
            };
        }
    }
}