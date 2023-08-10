using MediatR;
using MicroContent.Products.Domain.Interface;

namespace MicroContent.Products.Application.Commands;

public class UpdateProduct : IRequest<bool>
{
    public string AdressFrom { get; set; }
    public string AdressTo { get; set; }
    public string LocationByIp { get; set; }

    public UpdateProduct(string adressFrom, string adressTo, string locationByIp)
    {
        AdressFrom = adressFrom;
        AdressTo = adressTo;
        LocationByIp = locationByIp;
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
        //await _productsService.Update();
        //await _productsHistoryService.Save();

        return true;
    }
}