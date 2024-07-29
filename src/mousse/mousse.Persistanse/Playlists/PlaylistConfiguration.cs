using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Playlists;
using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.Releases.Albums;
using mousse.Domain.Playlists.Releases.EPs;
using mousse.Domain.Playlists.UserPlaylists;
using mousse.Domain.Users;
using Single = mousse.Domain.Playlists.Releases.Singles.Single;

namespace mousse.Persistence.Playlists;

public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.Id);

        builder.HasDiscriminator(p => p.PlaylistType)
            .HasValue<UserPlaylist>(PlaylistType.Playlist)
            .HasValue<Single>(PlaylistType.Single)
            .HasValue<EP>(PlaylistType.EP)
            .HasValue<Album>(PlaylistType.Album);

        builder.ComplexProperty(
            g => g.PlaylistName, 
            builder => builder.Property(p => p.Value)
                .HasColumnName(nameof(PlaylistName))
                .HasMaxLength(PlaylistName.MaxLenght)
                .IsRequired());

        builder.Property(p => p.PlaylistType)
            .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(u => u.AuthorId);

        builder.HasMany(p => p.Tracks)
            .WithMany(t => t.Playlists);
    }
}
