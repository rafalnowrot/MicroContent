using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Interface;
using System.Net.Sockets;
using MassTransit;
using MassTransit.Transports;
using MicroContent.Commons;

namespace MicroContent.Products.Infrastructure.Services;

public class ProductsService : IRepository<Product>
{
    private readonly ProductsDbContext _context;
    private readonly IBus _bus;
    public readonly IPublishEndpoint _publishEndpoint;
    public IUnitOfWork UnitOfWork => _context;

    public ProductsService(ProductsDbContext context, IBus bus, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _bus = bus;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return _context.Products.AsEnumerable();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }


    public async Task Save(Product request)
    {
        _context.Products.Add(request);
       // _context.SaveChanges();
       // await SendProductToCompanyX(request);
    }

    public async Task SendProductToCompanyX(Product product)
    {
        if (product != null)
        {
            Uri uri = new Uri("rabbitmq://localhost/productQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(new CompanyProduct {Id = product.GetId.ToString(), Name = product.GetName, Price = product.GetPrice});
           // await _publishEndpoint.Publish<Product>(product);
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
    }

    public async Task<Product> GetById(Guid id)
    {
        return  _context.Products.FirstOrDefault(x=> x.GetId == id);
    }

    public async Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
