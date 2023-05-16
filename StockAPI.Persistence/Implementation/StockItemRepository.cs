using StockAPI.Domain.AggregationModels.StockItemAggregate;
using StockAPI.Domain.AggregationModels.ValueObjects;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Persistence.Implementation
{
    public class StockItemRepository : IStockItemRepository
    {
        public Task<StockItem> CreateAsync(StockItem itemToCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StockItem> UpdateAsync(StockItem itemToUpdate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<StockItem>> FindBySkusAsync(IReadOnlyList<Sku> sku, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<StockItem>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<StockItem>> FindByItemTypeAsync(long itemTypeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}