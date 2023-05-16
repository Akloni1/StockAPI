using StockAPI.Application.Models;

namespace StockAPI.Application.Queries.StockItemAggregate.Responses
{
    public class GetItemTypesQueryResponse : IItemsModel<ItemTypeDto>
    {
        public IReadOnlyList<ItemTypeDto> Items { get; set; }
    }
}