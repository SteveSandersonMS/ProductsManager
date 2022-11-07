using Microsoft.EntityFrameworkCore;

namespace ProductsManager.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Product>().HasIndex(nameof(Product.ModifiedTicks), nameof(Product.ProductId));
    }

    // Inventory
    public DbSet<Product> Products { get; set; } = default!;
}
