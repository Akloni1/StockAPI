using StockAPI.Infrastructure.Middlewares;

namespace StockAPI.Infrastructure.StartupFilters
{
    internal class VersionStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                next(app);
            };
        }
    }
}