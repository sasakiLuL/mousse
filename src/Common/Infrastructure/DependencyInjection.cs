using Application.Authentication;
using Authorization.Extensions;
using Infrastructure.Authentication;
using Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationOptions>(configuration.GetSection(AuthenticationOptions.Section));

        services.AddHttpContextAccessor();

        services.AddKeycloakAuthentication(configuration);

        services.AddScoped<IUserCredentialsProvider, UserCredentialsProvider>();

        return services;
    }
}
