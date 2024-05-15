using System.Text.Json;
using Blog.Enums;
using Blog.Models.ViewModels;
using Blog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Admin.Articles;

public class AddModel : PageModel
{
    [BindProperty]
    public ArticleRequest Dto { get; set; } = new();
    [BindProperty]
    public IFormFile FileImage { get; set; }

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
        var notification = new Notification
        {
            Message = "Record saved successfully",
            Type = NotificationType.Success
        };
        TempData["Notification"] = JsonSerializer.Serialize(notification);
        return RedirectToPage("/Admin/Articles/List");
    }
}
