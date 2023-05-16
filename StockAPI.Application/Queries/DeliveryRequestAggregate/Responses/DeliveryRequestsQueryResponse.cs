using StockAPI.Application.Models;

namespace StockAPI.Application.Queries.DeliveryRequestAggregate.Responses
{
    public class DeliveryRequestsQueryResponse : IItemsModel<DeliveryRequestItem>
    {
        public IReadOnlyList<DeliveryRequestItem> Items { get; set; }
    }
}