using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mousse.Application.Abstractions.Data;
using mousse.Domain.Accesses;
using mousse.Domain.Followers;
using mousse.Domain.Playlists;
using mousse.Domain.Tags;
using mousse.Domain.Users;
using mousse.Persistence.Accesses;
using mousse.Persistence.Followers;
using mousse.Persistence.Playlists;
using mousse.Persistence.Tags;
using mousse.Persistence.Users;

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

        services.AddScoped<IAccessRepository, AccessRepository>();

        services.AddScoped<IFollowerRepository, FollowerRepository>();

        services.AddScoped<IPlaylistRepository, PlaylistRepository>();

        services.AddScoped<ITagRepository, TagRepository>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
