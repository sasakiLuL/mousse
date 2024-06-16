using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace mousse.Persistence.Migrations;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

        using MousseContext context = 
            serviceScope.ServiceProvider.GetRequiredService<MousseContext>();

        context.Database.Migrate();
    }
}
