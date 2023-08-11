using MediatR;
using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Types;
using MicroContent.Products.Domain.Value_Objects;

namespace MicroContent.Products.Application.Commands;

public class PostProduct : IRequest<bool>
{
    public ProductId Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductType Status { get; set; }

    public PostProduct(Guid id, string name, decimal price, string productType)
    {
        Id = new ProductId(id);
        Name = name;
        Price = price;
        Status = new ProductType(productType);
    }
}

public class PostProductHandler : IRequestHandler<PostProduct, bool>
{
    private IRepository<Domain.Models.Product> _productsRepository;

    public PostProductHandler(IRepository<Domain.Models.Product> productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<bool> Handle(PostProduct request, CancellationToken cancellationToken)
    {
        await _productsRepository.Save(
            new Product
            {
                CreatedDate = DateTime.Now,
                Id = new Guid(), Name = request.Name,
                Price = request.Price,
                Status = request.Status.Value
            });

        return true;
    }
}
