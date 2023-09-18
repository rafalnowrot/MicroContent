using MediatR;
using MicroContent.Products.Application.Dto;
using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Types;
using MicroContent.Products.Domain.Value_Objects;

namespace MicroContent.Products.Application.Queries;

public record GetProductsList() : IRequest<IEnumerable<ProductDto>>;

public class GetProductsListHandler : IRequestHandler<GetProductsList, IEnumerable<ProductDto>>
{
    private IRepository<Domain.Models.Product> _productsService;

    public GetProductsListHandler(IRepository<Domain.Models.Product> productsService)
    {
        _productsService = productsService;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsList request, CancellationToken cancellationToken)
    {
        var response = (await _productsService.GetAll())
            .Select(x=>new ProductDto
            {
                Id = x.GetId, 
                Name = x.GetName,
                Price = x.GetPrice,
                Status = x.GetStatus
            }).AsEnumerable();

        return response;
    }
}
