using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Persistence.Users;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.Id);

        builder.OwnsOne(g => g.UserName, builder => {

            builder.WithOwner();

            builder.Property(p => p.Value)
                .HasColumnName(nameof(UserName))
                .HasMaxLength(UserName.MaxLenght)
                .IsRequired();
        });

        builder.HasMany(u => u.Subscribers)
            .WithMany();

        builder.HasMany(u => u.Tracks)
            .WithMany(t => t.Artists);

        builder.HasMany(u => u.SavedPlaylists)
            .WithMany(sp => sp.Users);

        builder.HasMany(cp => cp.CreatedPlaylists)
            .WithMany(cp => cp.Owners);

        builder.HasOne(u => u.LikedPlaylist)
            .WithOne()
            .HasForeignKey<User>(u => u.LikedPlaylistId)
            .IsRequired();
    }
}
