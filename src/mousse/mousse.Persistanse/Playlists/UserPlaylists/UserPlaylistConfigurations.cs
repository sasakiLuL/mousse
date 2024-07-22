using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Playlists.UserPlaylists;
using mousse.Domain.Users;

namespace mousse.Persistence.Playlists.UserPlaylists;

public class UserPlaylistConfigurations : IEntityTypeConfiguration<UserPlaylist>
{
    public void Configure(EntityTypeBuilder<UserPlaylist> builder)
    {
        builder.HasOne<User>()
            .WithOne()
            .HasForeignKey<User>(u => u.LikedPlaylistId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
