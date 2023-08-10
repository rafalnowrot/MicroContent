using MediatR;
using MicroContent.Transactions.Domain.Interface.Transactions;
using MicroContent.Transactions.Domain.Exeptions;

namespace MicroContent.Transactions.Application.Commands;

public class SetTransaction : IRequest<bool>
{
    public string AdressFrom { get; set; }
    public string AdressTo { get; set; }
    public string LocationByIp { get; set; }

    public SetTransaction(string adressFrom, string adressTo, string locationByIp)
    {
        AdressFrom = adressFrom;
        AdressTo = adressTo;
        LocationByIp = locationByIp;
    }
}

public class SetTransactionHandler : IRequestHandler<SetTransaction, bool>
{
    private IRepository<Domain.Models.Transaction> _transactionRepository;

    public SetTransactionHandler(IRepository<Domain.Models.Transaction> transactionService)
    {
        _transactionRepository = transactionService;
    }

    public async Task<bool> Handle(SetTransaction request, CancellationToken cancellationToken)
    {
        if (request.AdressTo.ToUpper().Contains("XXXXX"))
        {
            throw new InvalidAdressExeption(request.AdressTo);
        }

        await _transactionRepository.Save(request.AdressFrom, request.AdressTo,
                request.LocationByIp);

        return true;
    }
}