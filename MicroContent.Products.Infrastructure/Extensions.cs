using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Models;
using MicroContent.Products.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MicroContent.Products.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services
                .AddScoped<IRepository<Product>, ProductsService>()
                .AddScoped<IRepository<ProductPriceHistory>, ProductHistoryService>()
        .AddDbContext<ProductsDbContext>(options =>
            options.UseSqlServer
            ("data source=DESKTOP-4LM8G0M;initial catalog=ProductsDB;trusted_connection=true;Trust Server Certificate = true"));
    }
}