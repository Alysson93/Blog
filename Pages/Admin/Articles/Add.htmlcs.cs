using Blog.Models;
using Blog.Models.ViewModels;
using Blog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Admin.Articles;

public class AddModel : PageModel
{
    [BindProperty]
    public ArticleRequest Dto { get; set; } = new();

    private IArticleRepository _repository;

    public AddModel(IArticleRepository repository)
    {
        _repository = repository;
    }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        await _repository.Create(Dto);
        TempData["Message"] = "Article saved successfully!";
        return RedirectToPage("/Admin/Articles/List");
    }
}
