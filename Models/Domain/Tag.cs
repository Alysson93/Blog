namespace Blog.Models;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ArticleId { get; set; }
}