using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ImageController : Controller
{

    [HttpGet]
    public IActionResult Index()
    {
        return Ok("this is a images get method");
    }

}