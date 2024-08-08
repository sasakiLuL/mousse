using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace mousse.Application;

public static class DependecyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
