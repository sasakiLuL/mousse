using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Users.Domain.Users;
using Modules.Users.Domain.Users.Emails;
using Modules.Users.Persistence.Constants;
using mousse.Domain.Users.UserNames;

namespace Modules.Users.Persistence.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.Users);

        builder.HasKey(t => t.Id);

        builder.HasIndex(t => t.Id);

        builder.Property(p => p.Id)
            .HasColumnName("user_id")
            .IsRequired();

        builder.ComplexProperty(p => p.UserName, propBuilder =>
        {
            propBuilder.Property(x => x.Value)
                .HasColumnName("user_name")
                .HasMaxLength(UserName.MaximumLength)
                .IsRequired();
        });

        builder.ComplexProperty(p => p.Email, propBuilder =>
        {
            propBuilder.Property(x => x.Value)
                .HasColumnName("email")
                .HasMaxLength(Email.MaximumLength)
                .IsRequired();
        });

        builder.Property(p => p.IdentityServiceUserId)
            .HasColumnName("identity_service_user_id")
            .IsRequired();
    }
}
