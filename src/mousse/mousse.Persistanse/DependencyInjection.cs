using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mousse.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("mousse") ?? 
            throw new ArgumentNullException("Connection string is not exist");

        services.AddDbContext<MousseContext>(options => 
            options.UseNpgsql(connectionString, options => 
                options.EnableRetryOnFailure()
            ));

        return services;
    }
}
