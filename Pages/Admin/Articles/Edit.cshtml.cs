using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Admin.Articles;

public class EditModel : PageModel
{
    [BindProperty]
    public Article Article { get; set; } = new();

    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet(Guid id)
    {
        var article = _context.Articles.Find(id);
        if (article != null) Article = article;
    }

    public IActionResult OnPost()
    {
        var article = _context.Articles.Find(Article.Id);
        if (article == null) return Page();
        article.Title = Article.Title;
        article.Description = Article.Description;
        article.Content = Article.Content;
        article.ImageUrl = Article.ImageUrl;
        article.Slug = Article.Slug;
        article.Author = Article.Author;
        article.Visible = Article.Visible;
        _context.SaveChanges();
        return RedirectToPage("/admin/articles/list");
    }
}