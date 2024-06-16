using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Playlists;
using mousse.Domain.Tracks;

namespace mousse.Persistence.Tracks;

public class TracksConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.HasIndex(t => t.Id);

        builder.OwnsOne(g => g.TrackName, builder => {

            builder.WithOwner();

            builder.Property(p => p.Value)
                .HasColumnName(nameof(TrackName))
                .HasMaxLength(TrackName.MaxLenght)
                .IsRequired();
        });

        builder.OwnsOne(g => g.Duration, builder => {

            builder.WithOwner();

            builder.Property(p => p.Seconds)
                .HasColumnName(nameof(Duration))
                .IsRequired();
        });

        builder.HasMany(t => t.Playlists)
            .WithMany(p => p.Tracks)
            .UsingEntity("PlaylistTrack");

        builder.HasMany(t => t.Artists)
            .WithMany(u => u.Tracks)
            .UsingEntity("ArtistTrack");

        builder.HasMany(t => t.Genres)
            .WithMany(g => g.Tracks)
            .UsingEntity("GenreTrack");
    }
}
