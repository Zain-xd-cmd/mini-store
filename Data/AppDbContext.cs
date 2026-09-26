
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<Order> Orders {get; set;}
    public DbSet<OrderItem> OrderItems {get; set;}
    public DbSet<Customer> Customers {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
}