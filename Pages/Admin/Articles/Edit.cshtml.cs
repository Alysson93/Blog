using Blog.Models;
using Blog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Admin.Articles;

public class EditModel : PageModel
{
    [BindProperty]
    public Article Article { get; set; } = new();

    private readonly IArticleRepository _repository;

    public EditModel(IArticleRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGet(Guid id)
    {
        var article = await _repository.ReadById(id);
        if (article != null) Article = article;
    }

    public async Task<IActionResult> OnPostEdit()
    {
        if (await _repository.Update(Article))
            return RedirectToPage("/admin/articles/list");
        return Page();
    }

    public async Task<IActionResult> OnPostDelete()
    {
        if (await _repository.Delete(Article.Id))
            return RedirectToPage("/admin/articles/list");
        return Page();
    }
}
