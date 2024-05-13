using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Blog.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly Account _account;

    public ImageRepository(IConfiguration config)
    {
        _account = new Account(
            config.GetSection("Cloudinary")["CloudName"],
            config.GetSection("Cloudinary")["ApiKey"],
            config.GetSection("Cloudinary")["ApiSecret"]
        );
    }

    public async Task<string?> Upload(IFormFile file)
    {
        var client = new Cloudinary(_account);
        var result = await client.UploadAsync(new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, file.OpenReadStream()),
            DisplayName = file.FileName
        });
        if (result != null && result.StatusCode == HttpStatusCode.OK)
        {
            return result.SecureUrl.ToString();
        }
        return null;
    }
}
