namespace backend.Helpers;

using Microsoft.EntityFrameworkCore;
using backend.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("DbConnection"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<FavoriteQuote> FavoriteQuotes { get; set; }
}