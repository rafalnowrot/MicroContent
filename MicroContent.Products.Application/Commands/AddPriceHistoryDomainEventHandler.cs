using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroContent.Products.Domain.Events;
using MicroContent.Products.Domain.Interface;
using MicroContent.Products.Domain.Models;

namespace MicroContent.Products.Application.Commands;

public class AddPriceHistoryDomainEventHandler: INotificationHandler<PriceHistoryDomainEvent>
{
    private readonly IRepository<ProductPriceHistory> _productHistoryService;

    public AddPriceHistoryDomainEventHandler(IRepository<ProductPriceHistory> productHistoryService)
    {
        _productHistoryService = productHistoryService;
    }

    public async Task Handle(PriceHistoryDomainEvent notification, CancellationToken cancellationToken)
    {
        await _productHistoryService.Save(
            new ProductPriceHistory
            {
                CreatedDate = notification.CreatedDate,
                Price = notification.Price,
                ProductId = notification.ProductId
            });
    }
}

