using StockAPI.Infrastructure.Middlewares;

namespace StockAPI.Infrastructure.StartupFilters
{
    internal class HttpStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<RequestLoggingMiddleware>();
                app.UseMiddleware<ResponseLoggingMiddleware>();
                app.UseRouting();
                app.UseEndpoints(endpoints => endpoints.MapControllers());
                next(app);
            };
        }
    }
}