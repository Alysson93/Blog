using Blog.Data;
using Blog.Models;
using Blog.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories;

public class ArticleRepository : IArticleRepository
{
    private AppDbContext _context;

    public ArticleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Article> Create(ArticleRequest request)
    {
        var article = new Article
        {
            Title = request.Title,
            Description = request.Description,
            Content = request.Content,
            ImageUrl = request.ImageUrl,
            Slug = request.Slug,
            Author = request.Author,
            Visible = request.Visible
        };
        await _context.Articles.AddAsync(article);
        await _context.SaveChangesAsync();
        return article;
    }

    public async Task<bool> Delete(Guid id)
    {
        var article = await this.ReadById(id);
        if (article == null) return false;
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Article>> Read()
    {
        return await _context.Articles.ToListAsync();
    }

    public async Task<Article?> ReadById(Guid id)
    {
        return await _context.Articles.FindAsync(id);
    }

    public async Task<bool> Update(Article article)
    {
        var art = await this.ReadById(article.Id);
        if (art == null) return false;
        art.Title = article.Title;
        art.Description = article.Description;
        art.Content = article.Content;
        art.ImageUrl = article.ImageUrl;
        art.Slug = article.Slug;
        art.Author = article.Author;
        art.Visible = article.Visible;
        await _context.SaveChangesAsync();
        return true;
    }
}
