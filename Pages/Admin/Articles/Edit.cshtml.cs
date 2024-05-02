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

    public async Task OnGet(Guid id)
    {
        Article = await _context.Articles.FindAsync(id);
    }

    public async Task<IActionResult> OnPostEdit()
    {
        var article = await _context.Articles.FindAsync(Article.Id);
        if (article == null) return Page();
        article.Title = Article.Title;
        article.Description = Article.Description;
        article.Content = Article.Content;
        article.ImageUrl = Article.ImageUrl;
        article.Slug = Article.Slug;
        article.Author = Article.Author;
        article.Visible = Article.Visible;
        await _context.SaveChangesAsync();
        return RedirectToPage("/admin/articles/list");
    }

    public async Task<IActionResult> OnPostDelete()
    {
        var article = await _context.Articles.FindAsync(Article.Id);
        if (article == null) return Page();
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return RedirectToPage("/admin/articles/list");
    }
}
