using StockAPI.Domain.Common;

namespace StockAPI.Domain.AggregationModels.StockItemAggregate;

public sealed class Item : Entity
{
    public ItemType Type { get; }

    public Item(ItemType type)
    {
        Id = type.Id;
        Type = type;
    }
}