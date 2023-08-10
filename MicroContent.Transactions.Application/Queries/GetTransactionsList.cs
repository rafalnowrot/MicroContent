using AutoMapper;
using MediatR;
using MicroContent.Transactions.Application.Dto;
using MicroContent.Transactions.Domain.Interface.Transactions;
using MicroContent.Transactions.Infrastructure.AutoMapper;

namespace MicroContent.Transactions.Application.Queries;

public record GetTransactionsList() : IRequest<List<TransactionDto>>;

public class GetTransactionListHandler : IRequestHandler<GetTransactionsList, List<TransactionDto>>
{
    private IRepository<Domain.Models.Transaction> _transactionRepository;
    private readonly IMapper _mapper;

    public GetTransactionListHandler(IRepository<Domain.Models.Transaction> transactionService)
    {
        _transactionRepository = transactionService;
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperProfile());
        });
        _mapper = mappingConfig.CreateMapper();
    }

    public async Task<List<TransactionDto>> Handle(GetTransactionsList request, CancellationToken cancellationToken)
    {
        var response = (await _transactionRepository.GetAll()).ToList();

        return _mapper.Map<List<TransactionDto>>(response);
    }
}
