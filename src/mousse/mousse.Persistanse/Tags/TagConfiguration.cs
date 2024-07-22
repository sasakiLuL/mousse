using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mousse.Domain.Tags;
using mousse.Domain.Tags.TagNames;

namespace mousse.Persistence.Genres;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(g => g.Id);

        builder.ComplexProperty(
            g => g.TagName, 
            builder => builder.Property(p => p.Value)
                .HasColumnName(nameof(TagName))
                .HasMaxLength(TagName.MaxLenght)
                .IsRequired());
    }
}
