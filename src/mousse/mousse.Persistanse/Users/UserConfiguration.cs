using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Playlists.UserPlaylists;
using mousse.Domain.Users;
using mousse.Domain.Users.Emails;
using mousse.Domain.Users.UserNames;

namespace mousse.Persistence.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(u => u.Id);

        builder.ComplexProperty(
            g => g.UserName,
            builder => builder.Property(p => p.Value).HasColumnName(nameof(UserName)));

        builder.ComplexProperty(
            g => g.Email,
            builder => builder.Property(p => p.Value).HasColumnName(nameof(Email)));

        builder.HasOne<UserPlaylist>()
            .WithOne()
            .HasForeignKey<User>(u => u.LikedPlaylistId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
