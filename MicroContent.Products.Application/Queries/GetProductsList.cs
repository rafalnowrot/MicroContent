using MediatR;
using MicroContent.Products.Application.Dto;
using MicroContent.Products.Domain.Interface;

namespace MicroContent.Products.Application.Queries;

public record GetProductsList() : IRequest<List<ProductDto>>;

public class GetProductsListHandler : IRequestHandler<GetProductsList, IEnumerable<ProductDto>>
{
    private IRepository<Domain.Models.Product> _productsService;

    public GetProductsListHandler(IRepository<Domain.Models.Product> productsService)
    {
        _productsService = productsService;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsList request, CancellationToken cancellationToken)
    {
        var response = (await _productsService.GetAll()).ToList();

        return  Enumerable.Empty<ProductDto>();
    }
}
