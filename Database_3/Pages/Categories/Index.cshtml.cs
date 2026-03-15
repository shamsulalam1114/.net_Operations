using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Database_3.EF;
using Database_3.EF.Tables;

namespace Database_3.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly ShopDbContext _context;

    public IndexModel(ShopDbContext context)
    {
        _context = context;
    }

    public IList<Category> Categories { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Categories = await _context.Categories.ToListAsync();
    }
}