using StockAPI.Enums;

namespace StockAPI.Application.Models
{
    public class DeliveryRequestItem
    {
        public long Id { get; set; }

        public long DeliveryRequestId { get; set; }

        public DeliveryRequestStatus RequestStatus { get; set; }

        public IReadOnlyList<long> SkusCollection { get; set; }
    }
}