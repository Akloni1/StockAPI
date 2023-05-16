using System.Text.Json;

namespace StockAPI.Infrastructure.Extensions
{
    internal static class JsonSerializerOptionsFactory
    {
        internal static JsonSerializerOptions Default = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
}