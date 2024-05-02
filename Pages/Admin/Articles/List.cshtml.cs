using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Pages.Admin.Articles;

public class ListModel : PageModel
{
    public List<Article> Articles { get; set; } = new();
    private readonly AppDbContext _context;

    public ListModel(AppDbContext context)
    {
        _context = context;
    }

    public async Task OnGet()
    {
        Articles = await _context.Articles.ToListAsync();
    }
}