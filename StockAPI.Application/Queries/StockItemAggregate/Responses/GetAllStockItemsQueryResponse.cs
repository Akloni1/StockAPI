using StockAPI.Application.Models;

namespace StockAPI.Application.Queries.StockItemAggregate.Responses
{
    public class GetAllStockItemsQueryResponse : IItemsModel<StockItemDto>
    {
        public IReadOnlyList<StockItemDto> Items { get; set; }
    }
}