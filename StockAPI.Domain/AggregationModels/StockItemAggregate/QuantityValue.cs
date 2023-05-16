using StockAPI.Domain.Common;

namespace StockAPI.Domain.AggregationModels.StockItemAggregate;

public class QuantityValue : ValueObject
{
    public QuantityValue(int? value)
    {
        Value = value;
    }

    public int? Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}