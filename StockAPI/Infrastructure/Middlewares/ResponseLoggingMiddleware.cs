using System.Text.Json;
using StockAPI.Infrastructure.Extensions;

namespace StockAPI.Infrastructure.Middlewares
{
    internal class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            if (string.Equals(context.Request.ContentType, "application/grpc", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }
            
            var originalBodyStream = context.Response.Body;
            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;
            
            await _next(context);

            try
            {
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
            
                var serializedJsonOutput = JsonSerializer.Serialize(text, JsonSerializerOptionsFactory.Default);
                _logger.LogInformation("Request logged");
                _logger.LogInformation(serializedJsonOutput);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Could not log response");
            }
        }
    }
}