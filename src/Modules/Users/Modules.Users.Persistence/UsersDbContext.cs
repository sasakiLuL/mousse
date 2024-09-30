using Microsoft.EntityFrameworkCore;
using Modules.Users.Domain.Followers;
using Modules.Users.Domain.Users;
using Modules.Users.Persistence.Constants;
using System.Reflection;

namespace Modules.Users.Persistence;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; private set; }

    public DbSet<Follower> Followers { get; private set; }
}
