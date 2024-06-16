using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Genres;

namespace mousse.Persistence.Genres;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(g => g.Id);

        builder.OwnsOne(g => g.GenreName, builder => {

            builder.WithOwner();

            builder.Property(p => p.Value)
                .HasColumnName(nameof(GenreName))
                .HasMaxLength(GenreName.MaxLenght)
                .IsRequired(); 
        });

        builder.HasMany(g => g.Tracks)
            .WithMany(t => t.Genres);
    }
}
