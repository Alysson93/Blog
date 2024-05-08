using System.Text.Json;
using Blog.Models;
using Blog.Models.ViewModels;
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
        var notification = (string?) TempData["Notification"];
        if (notification != null)
            ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notification);
        Articles = await _repository.Read();
    }
}