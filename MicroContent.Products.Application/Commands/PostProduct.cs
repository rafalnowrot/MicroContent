using MediatR;
using MicroContent.Products.Domain.Events;
using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Types;
using MicroContent.Products.Domain.Value_Objects;

namespace MicroContent.Products.Application.Commands;

public class PostProduct : IRequest<bool>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }

    public PostProduct(string name, decimal price, string status)
    {
        Name = name;
        Price = price;
        Status = status;
    }
}

public class PostProductHandler : IRequestHandler<PostProduct, bool>
{
    private IRepository<MicroContent.Products.Domain.Models.Product> _productsRepository;
    private IRepository<Domain.Models.ProductPriceHistory> _productsHistoryService;

    public PostProductHandler(IRepository<Domain.Models.Product> productsService,
        IRepository<Domain.Models.ProductPriceHistory> productsHistoryService)
    {
        _productsRepository = productsService;
        _productsHistoryService = productsHistoryService;
    }

    public async Task<bool> Handle(PostProduct request, CancellationToken cancellationToken)
    {
        var productId = Guid.NewGuid();

        var product = new Product();

        product.SetId(productId);
        product.SetName(request.Name);
        product.SetPrice(request.Price);
        product.SetStatus("Unverified");


        var productHistoryFirstRowEvent = new PriceHistoryDomainEvent(productId,request.Price);
        product.AddDomainEvent(productHistoryFirstRowEvent);

        await _productsRepository.Save(product);
        await _productsRepository.SaveChangesAsync(cancellationToken);
        await _productsRepository.SendProductToCompanyX(product);

        return true;
    }
}
