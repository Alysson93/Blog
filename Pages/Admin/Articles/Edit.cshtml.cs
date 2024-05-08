using System.Text.Json;
using Blog.Enums;
using Blog.Models;
using Blog.Models.ViewModels;
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
        Notification notification = new();
        if (await _repository.Update(Article))
        {
            notification.Message ="Record updated successfully!";
            notification.Type = NotificationType.Success;
        } else
        {
            notification.Message ="Record Record update failed";
            notification.Type = NotificationType.Error; 
        }
        TempData["Notification"] = JsonSerializer.Serialize(notification);
        return RedirectToPage("/Admin/Articles/List");
    }

    public async Task<IActionResult> OnPostDelete()
    {
        Notification notification = new();
        if (await _repository.Delete(Article.Id))
        {
            notification.Message ="Record deleted successfully!";
            notification.Type = NotificationType.Success;
        } else
        {
            notification.Message ="Record delete failed";
            notification.Type = NotificationType.Error; 
        }
        TempData["Notification"] = JsonSerializer.Serialize(notification);
        return RedirectToPage("/Admin/Articles/List");
    }
}
