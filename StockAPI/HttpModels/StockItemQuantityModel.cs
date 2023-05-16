namespace StockAPI.HttpModels
{
    public record StockItemQuantityModel
    {
        public long Sku { get; init; }

        public int Quantity { get; init; }
    }
}