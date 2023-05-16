using MediatR;
using StockAPI.Domain.AggregationModels.StockItemAggregate;
using StockAPI.Domain.AggregationModels.ValueObjects;

namespace StockAPI.Domain.Events;

/// <summary>
/// Пришла поставка с новыми товарами
/// </summary>
public class SupplyArrivedWithStockItemsDomainEvent : INotification
{
    public Sku StockItemSku { get; }
    public ItemType ItemType { get; set; }
    public Quantity Quantity { get; }

    public ClothingSize ClothingSize { get; }

    public SupplyArrivedWithStockItemsDomainEvent(Sku stockItemSku,
        ItemType itemType,
        Quantity quantity,
        ClothingSize clothingSize)
    {
        StockItemSku = stockItemSku;
        ItemType = itemType;
        Quantity = quantity;
        ClothingSize = clothingSize;
    }
}