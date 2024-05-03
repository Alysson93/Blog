using Blog.Models;

namespace Blog.Repositories;

public interface IArticleRepository
{
    Task<Article> Create(Article article);
    Task<List<Article>> Read();
    Task<Article> ReadById(Guid id);
    Task<bool> Update(Article article);
    Task<bool> Delete(Guid id);
}