namespace StockAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
           // 
            
            return services;
        }
        
        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            // 

            return services;
        }

        public static IServiceCollection AddExternalServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // 
            
            return services;
        }
    }
}