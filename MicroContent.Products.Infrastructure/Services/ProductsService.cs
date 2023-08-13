using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Interface;
using System.Net.Sockets;
using MassTransit;

namespace MicroContent.Products.Infrastructure.Services;

public class ProductsService : IRepository<Product>
{
    private readonly ProductsDbContext _context;
    private readonly IBus _bus;

    public ProductsService(ProductsDbContext context, IBus bus)
    {
        _context = context;
        _bus = bus;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return _context.Products.AsEnumerable();
    }

    public async Task Save(Product request)
    {
        _context.Products.Add(request);
        _context.SaveChanges();
        await SendProductToCompanyX(request);
    }

    private async Task SendProductToCompanyX(Product product)
    {
        if (product != null)
        {
            Uri uri = new Uri("rabbitmq://localhost/productQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(product);
        }
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
