using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Admin.Articles;

public class ListModel : PageModel
{
    public List<Article> Articles { get; set; } = new();
    private readonly AppDbContext _context;

    public ListModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Articles = _context.Articles.ToList();
    }
}