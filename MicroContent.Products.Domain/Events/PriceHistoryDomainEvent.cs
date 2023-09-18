using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MicroContent.Products.Domain.Events;

public class PriceHistoryDomainEvent: INotification
{
    public int Id { get; set; }

    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }

    public PriceHistoryDomainEvent(Guid productId, decimal price)
    {
        ProductId = productId;
        Price = price;
        CreatedDate = DateTime.Now;
    }
}
