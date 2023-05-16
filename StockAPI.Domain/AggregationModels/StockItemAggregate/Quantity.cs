using StockAPI.Domain.Common;

namespace StockAPI.Domain.AggregationModels.StockItemAggregate;

public class Quantity : ValueObject
{
    public Quantity(int value)
    {
        Value = value;
    }

    public int Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}