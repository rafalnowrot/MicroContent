using MediatR;
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
    private IRepository<Domain.Models.Product> _productsRepository;
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
        await _productsRepository.Save(
            new Product
            {
                CreatedDate = DateTime.Now,
                Id = productId, 
                Name = request.Name,
                Price = request.Price,
                Status = request.Status
            });

        await _productsHistoryService.Save(
            new ProductPriceHistory
            {
                CreatedDate = DateTime.Now,
                Price = request.Price,
                ProductId = productId
            });

        return true;
    }
}
