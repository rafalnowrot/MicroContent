using MicroContent.Products.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroContent.Products.Infrastructure;

public class ProductsDbContext: DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductPriceHistory> ProductPriceHistoryList { get; set; } = null!;

    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
    {
    }
    
}