using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Persistence.Playlists;

public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.HasKey(p => p.Id);

        builder.OwnsOne(g => g.PlaylistName, builder => {

            builder.WithOwner();

            builder.Property(p => p.Value)
                .HasColumnName(nameof(PlaylistName))
                .HasMaxLength(PlaylistName.MaxLenght)
                .IsRequired();
        });

        builder.Property(p => p.PlaylistType)
            .IsRequired();

        builder.OwnsOne(g => g.Duration, builder => {

            builder.WithOwner();

            builder.Property(p => p.Seconds)
                .HasColumnName(nameof(Duration))
                .IsRequired();
        });

        builder.HasMany(p => p.Tracks)
            .WithMany(t => t.Playlists);

        builder.HasMany(p => p.Owners)
            .WithMany(u => u.CreatedPlaylists)
            .UsingEntity("OwnerPlaylist");

        builder.HasMany(p => p.Users)
            .WithMany(u => u.SavedPlaylists)
            .UsingEntity("UserPlaylist");

        builder.HasOne<User>()
            .WithOne(p => p.LikedPlaylist)
            .HasForeignKey<User>(u => u.LikedPlaylistId);
    }
}
