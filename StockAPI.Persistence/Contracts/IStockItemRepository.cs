using StockAPI.Domain.AggregationModels.StockItemAggregate;
using StockAPI.Domain.AggregationModels.ValueObjects;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Persistence.Contracts;

public interface IStockItemRepository : IRepository<StockItem>
{
    Task<StockItem> CreateAsync(StockItem itemToCreate, CancellationToken cancellationToken);

    Task<StockItem> UpdateAsync(StockItem itemToUpdate, CancellationToken cancellationToken);

    Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken);

    Task<IReadOnlyList<StockItem>> FindBySkusAsync(IReadOnlyList<Sku> sku, CancellationToken cancellationToken);

    Task<IReadOnlyList<StockItem>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<StockItem>> FindByItemTypeAsync(long itemTypeId, CancellationToken cancellationToken);
}