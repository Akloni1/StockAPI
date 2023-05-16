using StockAPI.Domain.AggregationModels.StockItemAggregate;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Persistence.Implementation
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        public Task<IEnumerable<Item>> GetAllTypes(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}