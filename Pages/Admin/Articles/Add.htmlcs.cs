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
        await _repository.Create(article);
        return RedirectToPage("/Admin/Articles/List");
    }
}
