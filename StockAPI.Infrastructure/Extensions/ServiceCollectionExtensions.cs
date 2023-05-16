using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using StockAPI.Application.Handlers.DomainEvent;
using StockAPI.Persistence.Contracts;
using StockAPI.Persistence.Contracts.Common;
using StockAPI.Persistence.Implementation;
using StockAPI.Persistence.Infrastructure;
using StockAPI.Persistence.Infrastructure.Implementation;

namespace StockAPI.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ReachedMinimumDomainEventHandler).Assembly));

            return services;
        }
        
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Подключаем БД
            
            //services.Configure<DatabaseConnectionOptions>(configuration.GetSection(nameof(DatabaseConnectionOptions)));
            
            //services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChangeTracker, ChangeTracker>();
            services.AddScoped<IQueryExecutor, QueryExecutor>();

            return services;
        }
        
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStockItemRepository, StockItemRepository>();
            services.AddScoped<IDeliveryRequestRepository, DeliveryRequestRepository>();
            services.AddScoped<IItemTypeRepository, ItemTypeRepository>();

            return services;
        }

    }