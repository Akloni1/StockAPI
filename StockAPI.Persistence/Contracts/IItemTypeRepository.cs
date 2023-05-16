using StockAPI.Domain.AggregationModels.StockItemAggregate;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Persistence.Contracts;

public interface IItemTypeRepository : IRepository<Item>
{
    Task<IEnumerable<Item>> GetAllTypes(CancellationToken token);
}