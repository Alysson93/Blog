using Blog.Models;
using Blog.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Admin.Articles;

public class ListModel : PageModel
{
    public List<Article> Articles { get; set; } = new();
    private readonly IArticleRepository _repository;

    public ListModel(IArticleRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGet()
    {
        var message = (string?)TempData["Message"];
        ViewData["Message"] = message;
        Articles = await _repository.Read();
    }
}