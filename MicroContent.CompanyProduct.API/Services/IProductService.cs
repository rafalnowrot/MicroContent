using MicroContent.CompanyProduct.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroContent.CompanyProduct.API.Services;

public interface IProductService
{
    Task Save(Product product);
    Task<IEnumerable<Product>> GetAllProducts();
}

public class ProductService : IProductService
{
    private readonly MongoDbContext _context = null;

    public ProductService(IOptions<Settings> settings)
    {
        _context = new MongoDbContext(settings);
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    { 
        return await _context.Products.Find(_ => true).ToListAsync();
    }
    
    public async Task Save(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }
}
