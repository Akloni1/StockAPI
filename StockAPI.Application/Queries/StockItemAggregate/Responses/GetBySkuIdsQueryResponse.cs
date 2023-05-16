using StockAPI.Application.Models;

namespace StockAPI.Application.Queries.StockItemAggregate.Responses
{
    public class GetBySkuIdsQueryResponse
    {
        public IReadOnlyList<StockItemDto> Items { get; set; }
    }
}