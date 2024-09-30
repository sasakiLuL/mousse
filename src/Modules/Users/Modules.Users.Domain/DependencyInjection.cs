using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Domain.Followers;
using System.Reflection;

namespace Modules.Users.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersDomain(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IFollowerService, FollowerService>();

        return services;
    }
}
