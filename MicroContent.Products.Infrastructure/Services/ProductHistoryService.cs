
using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Models;

namespace MicroContent.Products.Infrastructure.Services;

public class ProductHistoryService: IRepository<ProductPriceHistory>
{
    private readonly ProductsDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

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
        _context.ProductPriceHistoryList.Add(request);
    }

    public async Task Delete(ProductPriceHistory request)
    {
        throw new NotImplementedException();
    }

    public async Task Update(ProductPriceHistory request)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductPriceHistory> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductPriceHistory> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task SendProductToCompanyX(ProductPriceHistory product)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

