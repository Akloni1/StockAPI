using MediatR;
using StockAPI.Domain.AggregationModels.ValueObjects;

namespace StockAPI.Domain.Events;

public class ReachedMinimumStockItemsNumberDomainEvent : INotification
{
    public Sku StockItemSku { get; }

    public ReachedMinimumStockItemsNumberDomainEvent(Sku stockItemSku)
    {
        StockItemSku = stockItemSku;
    }
}