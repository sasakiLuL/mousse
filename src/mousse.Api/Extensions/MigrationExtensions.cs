using Microsoft.EntityFrameworkCore;

namespace mousse.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations<TContext>(this IApplicationBuilder app) where TContext : DbContext
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

        using TContext context =
            serviceScope.ServiceProvider.GetRequiredService<TContext>();

        context.Database.Migrate();
    }
}
