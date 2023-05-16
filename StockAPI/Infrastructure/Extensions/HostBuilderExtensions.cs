using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using StockAPI.Infrastructure.Filters;
using StockAPI.Infrastructure.StartupFilters;

namespace StockAPI.Infrastructure.Extensions
{
    internal static class HostBuilderExtensions
    {
        internal static IHostBuilder ConfigureMicroserviceInfrastructure(this IHostBuilder builder)
        {
            return builder
                .ConfigureVersionEndpoint()
                .ConfigureHttp()
                .ConfigureSwagger();
        }

        private static IHostBuilder ConfigureVersionEndpoint(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, VersionStartupFilter>();
            });

            return builder;
        }
        
        private static IHostBuilder ConfigureSwagger(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "StockApi", Version = "v1"});
                    options.CustomSchemaIds(x => x.FullName);
                    var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                    options.IncludeXmlComments(xmlFilePath);
                });
            });
            
            return builder;
        }
        
        private static IHostBuilder ConfigureHttp(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddSingleton<IStartupFilter, HttpStartupFilter>();
            });

            return builder;
        }

        public static IWebHostBuilder ConfigurePorts(this IWebHostBuilder builder)
        {

            var httpPortEnv = Environment.GetEnvironmentVariable("HTTP_PORT");
            if (!int.TryParse(httpPortEnv, out var httpPort))
            {
                httpPort = 5000;
            }

            if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
            {
                httpPort = 80;
            }
            
            builder.ConfigureKestrel(
                    options =>
                    {
                        Listen(options, httpPort, HttpProtocols.Http1);
                    });
            
            return builder;
        }

        static void Listen(KestrelServerOptions kestrelServerOptions, int? port, HttpProtocols protocols)
        {
            if (port == null)
                return;

            var address = IPAddress.Any;


            kestrelServerOptions.Listen(address, port.Value, listenOptions => { listenOptions.Protocols = protocols; });
        }
    }
}