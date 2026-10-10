namespace DesignPatterns.RepositoryPattern;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Use InMemory database instead of SQL
        optionsBuilder.UseInMemoryDatabase("MyInMemoryDb");
    }
    // DbSet for Products table
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
}
