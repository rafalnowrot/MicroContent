using MicroContent.Products.Domain.Types;

namespace MicroContent.Products.Domain.Models;

public class ProductPriceHistory
{
    public int Id { get; set; }

    public Guid ProductId { get; set; }
    public decimal Price { get; set; } 
    public DateTime CreatedDate { get; set; }
}