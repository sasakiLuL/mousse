using Application.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Interceptors;
using Persistence.Options;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<DomainEventPublishingInterceptor>();

        services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();

        services.Configure<ConnectionStringOptions>(builder =>
        {
            builder.Value = configuration.GetConnectionString(ConnectionStringOptions.Section)
                ?? throw new ArgumentException("The connection string was not found.");
        });

        return services;
    }
}
