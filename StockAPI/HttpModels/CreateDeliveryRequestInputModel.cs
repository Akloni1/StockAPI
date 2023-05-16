namespace StockAPI.HttpModels
{
    public record CreateDeliveryRequestInputModel
    {
        public IReadOnlyList<DeliveryRequestModel> Items { get; init; } = Array.Empty<DeliveryRequestModel>();
    }
}