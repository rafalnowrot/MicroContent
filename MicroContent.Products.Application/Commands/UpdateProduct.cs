using MediatR;
using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Types;
using MicroContent.Products.Domain.Value_Objects;

namespace MicroContent.Products.Application.Commands;

public class UpdateProduct : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }

    public UpdateProduct(Guid id, string name, decimal price, string status)
    {
        Id = id;
        Name = name;
        Price = price;
        Status = status;
    }
}

public class UpdateProductHandler : IRequestHandler<UpdateProduct, bool>
{
    private IRepository<Domain.Models.Product> _productsService;
    private IRepository<Domain.Models.ProductPriceHistory> _productsHistoryService;


    public UpdateProductHandler(IRepository<Domain.Models.Product> productsService,
        IRepository<Domain.Models.ProductPriceHistory> productsHistoryService)
    {
        _productsService = productsService;
        _productsHistoryService = productsHistoryService;
    }

    public async Task<bool> Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var productToUpdate = await _productsService.GetById(request.Id);
        if (productToUpdate == null) { }

        productToUpdate.Name = request.Name;

        if (productToUpdate.Price != request.Price)
        {
            productToUpdate.Price = request.Price;
            await _productsHistoryService.Save(
                new ProductPriceHistory {CreatedDate = DateTime.Now,
                    Price = request.Price,
                    ProductId = request.Id});
        }
        productToUpdate.Status = request.Status;
        productToUpdate.LastUpdateDate = DateTime.UtcNow;

        await _productsService.Update(productToUpdate);

        return true;
    }
}