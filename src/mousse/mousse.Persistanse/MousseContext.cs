using Microsoft.EntityFrameworkCore;
using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Events;
using mousse.Domain.Genres;
using mousse.Domain.Playlists;
using mousse.Domain.Tracks;
using mousse.Domain.Users;
using System.Reflection;

namespace mousse.Persistence;

public class MousseContext : DbContext
{
    public MousseContext(DbContextOptions<MousseContext> options) : base(options) { }

    public DbSet<Playlist> Playlists { get; set; }

    public DbSet<User> Users {  get; set; }

    public DbSet<Track> Tracks { get; set; }

    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
