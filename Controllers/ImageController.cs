using System.Net;
using Blog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ImageController : Controller
{
    private IImageRepository _repository;

    public ImageController(IImageRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var imageUrl = await _repository.Upload(file);
        if (imageUrl == null) return Problem("Something went wrong", null, (int) HttpStatusCode.InternalServerError);
        return Json(new {link = imageUrl});
    }
}
