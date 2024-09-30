using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Modules.Users.Domain.Followers;
using Modules.Users.Domain.Users;
using Modules.Users.Persistence.Constants;
using Modules.Users.Persistence.Followers;
using Modules.Users.Persistence.Users;
using Persistence.Interceptors;
using Persistence.Options;

namespace Modules.Users.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersPersistence(this IServiceCollection services)
    {
        services.AddDbContext<UsersDbContext>((serviceProvider, options) => 
        {
            ConnectionStringOptions connectionString = serviceProvider.GetService<IOptions<ConnectionStringOptions>>()!.Value;

            options
                .UseNpgsql(connectionString.Value, dbContextOptionsBuilder =>
                    dbContextOptionsBuilder.MigrationsHistoryTable("Users__EFMigrationsHistory", Schemas.Users))
                    .UseSnakeCaseNamingConvention()
                .AddInterceptors(serviceProvider.GetService<DomainEventPublishingInterceptor>()!)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IFollowerRepository, FollowerRepository>();

        return services;
    }
}
