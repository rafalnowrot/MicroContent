using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Types;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using MicroContent.Products.Domain.Value_Objects;

namespace MicroContent.Products.Infrastructure;

public class ProductsDbContext: DbContext, IUnitOfWork
{
    private readonly MediatR.IMediator _mediator;

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductPriceHistory> ProductPriceHistoryList { get; set; } = null!;

    public ProductsDbContext(DbContextOptions<ProductsDbContext> options, MediatR.IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Potential fix for https://github.com/dotnet/aspnetcore/issues/43187
        var dpk = modelBuilder.Entity<Product>();
        dpk.HasKey(x => x.Id);
            
        dpk.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new ProductId(x));
        dpk.Property(x => x.Price);
        dpk.Property(x => x.Name);
        dpk.Property(x => x.Status)
            .HasConversion(x => x.Value, x => new ProductStatus(x));
        dpk.Property(x => x.CreatedDate);
        dpk.Property(x => x.LastUpdateDate);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Dispatch Domain Events collection. 
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
        await _mediator.DispatchDomainEventsAsync(this);

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
        // performed through the DbContext will be committed
        base.SaveChanges();

        return true;
    }
}