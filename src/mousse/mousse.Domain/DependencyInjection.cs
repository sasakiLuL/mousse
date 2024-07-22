using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mousse.Domain.Accesses;
using mousse.Domain.Followers;

namespace mousse.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAccessService, AccessService>();

        services.AddScoped<IFollowerService, FollowerService>();

        return services;
    }
}
