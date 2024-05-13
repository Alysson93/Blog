namespace Blog.Repositories;

public interface IImageRepository
{
    Task<string?> Upload(IFormFile file);
}
