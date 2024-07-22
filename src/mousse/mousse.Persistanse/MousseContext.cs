using Microsoft.EntityFrameworkCore;
using mousse.Domain.Accesses;
using mousse.Domain.Followers;
using mousse.Domain.Playlists;
using mousse.Domain.Playlists.Albums;
using mousse.Domain.Playlists.EPs;
using mousse.Domain.Playlists.Tracks;
using mousse.Domain.Playlists.UserPlaylists;
using mousse.Domain.Tags;
using mousse.Domain.Users;
using System.Reflection;
using Single = mousse.Domain.Playlists.Singles.Single;

namespace mousse.Persistence;

public class MousseContext : DbContext
{
    public MousseContext(DbContextOptions<MousseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Follower> Followers { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Playlist> Playlists { get; set; }

    public DbSet<Track> Tracks { get; set; }

    public DbSet<UserPlaylist> UserPlaylists { get; set; }

    public DbSet<Album> Albums { get; set; }

    public DbSet<EP> EPs { get; set; }

    public DbSet<Single> Singles { get; set; }

    public DbSet<Access> Accesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
