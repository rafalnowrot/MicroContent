using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Interface;

namespace MicroContent.Products.Infrastructure.Services;

public class ProductsService : IRepository<Product>
{
    private readonly ProductsDbContext _context;

    public ProductsService(ProductsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return _context.Products.AsEnumerable();
    }

    public async Task Save(Product request)
    {
        _context.Products.Add(request);
        _context.SaveChanges();
    }

    public async Task Delete(Product request)
    {
        _context.Products.Remove(request);
        _context.SaveChanges();
    }

    public async Task Update(Product request)
    {
        _context.Products.Update(request);
        _context.SaveChanges();
    }

    public async Task<Product> GetById(Guid id)
    {
        return _context.Products.FirstOrDefault(x=> x.Id == id);
    }

    public async Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
