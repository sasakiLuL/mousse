using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Application.Abstractions;
using Modules.Users.Authorization.IdentityProvider;
using Modules.Users.Communication.Users;
using Modules.Users.Infrastructure.Communication;

namespace Modules.Users.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddUsersInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<IIdentityService, IdentityService>();

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddScoped<IUserApi, UserApi>();

        return services;
    }
}
