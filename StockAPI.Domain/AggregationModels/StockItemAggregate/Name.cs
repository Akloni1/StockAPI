using StockAPI.Domain.Common;

namespace StockAPI.Domain.AggregationModels.StockItemAggregate;

public class Name : ValueObject
{
    public string Value { get; }
        
    public Name(string name)
    {
        Value = name;
    }
        
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}