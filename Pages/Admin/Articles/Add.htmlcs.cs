using Blog.Data;
using Blog.Models;
using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Admin.Articles;

public class AddModel : PageModel
{
    [BindProperty]
    public ArticleRequest Dto { get; set; } = new();

    private AppDbContext _context;

    public AddModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        var article = new Article
        {
            Title = Dto.Title,
            Description = Dto.Description,
            Content = Dto.Content,
            ImageUrl = Dto.ImageUrl,
            Slug = Dto.Slug,
            Author = Dto.Author,
            Visible = Dto.Visible
        };
        _context.Articles.Add(article);
        _context.SaveChanges();
        return RedirectToPage("/Admin/Articles/List");
    }
}
