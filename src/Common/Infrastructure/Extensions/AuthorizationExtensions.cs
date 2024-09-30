using Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Authorization.Extensions;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddKeycloakAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationOptions = configuration
            .GetSection(AuthenticationOptions.Section)
            .Get<AuthenticationOptions>() ?? throw new ArgumentException(nameof(AuthenticationOptions));

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.MetadataAddress = $"{authenticationOptions.Address}/realms/{authenticationOptions.Realm}/.well-known/openid-configuration";
                options.RequireHttpsMetadata = authenticationOptions.RequireHttpsMetadata ?? true;

                options.Audience = authenticationOptions.Audience;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = authenticationOptions.ValidateIssuer ?? true,
                    ValidIssuer = $"{authenticationOptions.Address}/realms/{authenticationOptions.Realm}",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddAuthorization();

        return services;
    }
}
