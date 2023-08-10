using MediatR;
using MicroContent.Products.Domain.Interface;

namespace MicroContent.Products.Application.Commands;

public class PostProduct : IRequest<bool>
{
    public string AdressFrom { get; set; }
    public string AdressTo { get; set; }
    public string LocationByIp { get; set; }

    public PostProduct(string adressFrom, string adressTo, string locationByIp)
    {
        AdressFrom = adressFrom;
        AdressTo = adressTo;
        LocationByIp = locationByIp;
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

       // await _productsRepository.Save(request.AdressFrom, request.AdressTo,
        //    request.LocationByIp);

        return true;
    }
}
