
using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Models;

namespace MicroContent.Products.Infrastructure.Services;

public class ProductHistoryService: IRepository<ProductPriceHistory>
{
    private readonly ProductsDbContext _context;

    public ProductHistoryService(ProductsDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductPriceHistory>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task Save(ProductPriceHistory request)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(ProductPriceHistory request)
    {
        throw new NotImplementedException();
    }

    public async Task Update(ProductPriceHistory request)
    {
        throw new NotImplementedException();
    }

    public async Task GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task GetById(int id)
    {
        throw new NotImplementedException();
    }
}

