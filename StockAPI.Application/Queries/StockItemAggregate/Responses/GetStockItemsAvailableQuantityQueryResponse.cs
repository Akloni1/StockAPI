using StockAPI.Application.Models;

namespace StockAPI.Application.Queries.StockItemAggregate.Responses
{
    public class GetStockItemsAvailableQuantityQueryResponse : IItemsModel<StockItemQuantityDto>
    {
        public IReadOnlyList<StockItemQuantityDto> Items { get; set; }
    }
}