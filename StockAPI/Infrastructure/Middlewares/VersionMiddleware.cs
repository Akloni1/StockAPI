using System.Reflection;
using System.Text.Json;
using StockAPI.Infrastructure.Extensions;

namespace StockAPI.Infrastructure.Middlewares
{
    internal class VersionMiddleware
    {
        // ReSharper disable once UnusedParameter.Local
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var executingAssembly = Assembly.GetExecutingAssembly().GetName();
            var version = executingAssembly.Version?.ToString() ?? "no version";
            var assemblyName = executingAssembly.Name;

            var result = new
            {
                Service = assemblyName,
                Version = version
            };
            var jsonResult = JsonSerializer.Serialize(result, JsonSerializerOptionsFactory.Default);
            await context.Response.WriteAsync(jsonResult);
        }
    }
}