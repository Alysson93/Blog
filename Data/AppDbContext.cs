using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class AppDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) {}
}