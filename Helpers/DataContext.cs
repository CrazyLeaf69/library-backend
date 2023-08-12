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

        // in memory database used for simplicity, change to a real db for production applications
        // options.UseInMemoryDatabase("TestDb");
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("AZURE_POSTGRESQL_CONNECTIONSTRING"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<FavoriteQuote> FavoriteQuotes { get; set; }
}