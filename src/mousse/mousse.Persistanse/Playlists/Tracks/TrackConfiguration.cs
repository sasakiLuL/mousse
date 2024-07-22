using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Playlists.Tracks;
using mousse.Domain.Playlists.Tracks.Durations;
using mousse.Domain.Playlists.Tracks.TrackNames;

namespace mousse.Persistence.Playlists.Tracks;

public class TrackConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasIndex(t => t.Id);

        builder.ComplexProperty(
            g => g.TrackName, 
            builder => builder.Property(p => p.Value)
                .HasColumnName(nameof(TrackName))
                .HasMaxLength(TrackName.MaxLenght)
                .IsRequired());

        builder.ComplexProperty(
            g => g.Duration, 
            builder => builder.Property(p => p.Seconds)
                .HasColumnName(nameof(Duration))
                .IsRequired());

        builder.HasMany(p => p.Playlists)
            .WithMany(p => p.Tracks);

        builder.HasMany(t => t.Tags)
            .WithMany();
    }
}
