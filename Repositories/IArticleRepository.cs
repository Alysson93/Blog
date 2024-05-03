using Blog.Models;
using Blog.Models.ViewModels;

namespace Blog.Repositories;

public interface IArticleRepository
{
    Task<Article> Create(ArticleRequest request);
    Task<List<Article>> Read();
    Task<Article?> ReadById(Guid id);
    Task<bool> Update(Article article);
    Task<bool> Delete(Guid id);
}