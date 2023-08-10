using MicroContent.Transactions.Domain.Interface.Transactions;
using MicroContent.Transactions.Domain.Models;
using MicroContent.Transactions.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MicroContent.Transactions.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        => services
            .AddScoped<IRepository<Transaction>, TransactionRepository>();
}
