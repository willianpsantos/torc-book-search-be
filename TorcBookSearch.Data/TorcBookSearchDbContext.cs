using Microsoft.EntityFrameworkCore;
using TorcBookSearch.Data.EntityConfigurations;
using TorcBookSearch.Models;

namespace TorcBookSearch.Data;

public sealed class TorcBookSearchDbContext(DbContextOptions<TorcBookSearchDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
     

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
