using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Accesses;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Persistence.Accesses;

public class AccessConfiguration : IEntityTypeConfiguration<Access>
{
    public void Configure(EntityTypeBuilder<Access> builder)
    {
        builder.HasKey(f => new { f.UserId, f.PlaylistId });

        builder.HasIndex(f => new { f.UserId, f.PlaylistId });

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Playlist>()
            .WithMany()
            .HasForeignKey(f => f.PlaylistId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Ignore(f => f.Id);
    }
}
