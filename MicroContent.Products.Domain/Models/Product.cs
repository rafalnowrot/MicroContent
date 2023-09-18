using MediatR;
using MicroContent.Products.Domain.Enums;
using MicroContent.Products.Domain.Events;
using MicroContent.Products.Domain.Types;
using MicroContent.Products.Domain.Value_Objects;
using System.ComponentModel.DataAnnotations;

namespace MicroContent.Products.Domain.Models;

public class Product : Entity
{
    public ProductId Id { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; } = 0;
    public ProductStatus Status { get; private set; } = null!;
    public DateTime CreatedDate { get; private set; }
    public DateTime? LastUpdateDate { get; private set; }

    private bool _isDraft;

    public Product()
    {

    }

    public Product(ProductId id,
        string name, 
        decimal price, 
        ProductStatus status, 
        DateTime createdDate,
        DateTime? lastUpdateDate)
    {
        Id = id;
        Name = name;
        Price = price;
        Status = status;
        CreatedDate = createdDate;
        LastUpdateDate = lastUpdateDate;
    }

    private Product(ProductId id,
        ProductStatus status )
    {
        Id = id;
        Status = status;
    }

private List<ProductPriceHistory> ProductHistory { get; set; }

    public Guid GetId => Id.Value;

    public string GetStatus => Status.Value;

    public void SetId(Guid id)
    {
        Id = new ProductId(id);
    }

    public void SetPrice(decimal price)
    {
        Price = price;
    }

    public decimal GetPrice => Price;
    
    public void SetStatus(string status)
    {
        Status = new ProductStatus(status);
    }

    public void SetName(string name) { Name = name; }
    
    public string GetName => Name;

    public static Product NewDraft()
    {
        var product = new Product
        {
            _isDraft = true
        };
        return product;
    }

    //Events
    
    private void NewPriceHistoryDomainEvent(Guid Id, decimal price)
    {
        var priceHistoryDomainEvent = new PriceHistoryDomainEvent( Id, price);

        this.AddDomainEvent(priceHistoryDomainEvent);
    }


}