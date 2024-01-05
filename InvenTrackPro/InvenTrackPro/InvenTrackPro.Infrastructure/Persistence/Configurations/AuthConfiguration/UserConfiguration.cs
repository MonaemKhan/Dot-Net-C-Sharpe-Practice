using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel;

namespace InvenTrackPro.Infrastructure.Persistence.Configurations.AuthConfiguration;

#nullable disable
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.HasData(new User
        {
            Id = 1,
            Email = "admin@localhost.com",
            NormalizedEmail = "ADMIN@LOCALHOST.COM",
            UserName = "admin@localhost.com",
            NormalizedUserName = "ADMIN@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(user: null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            TramsAndConditions = true
        }, new User
        {
            Id = 2,
            Email = "user@localhost.com",
            NormalizedEmail = "USER@LOCALHOST.COM",
            UserName = "user@localhost.com",
            NormalizedUserName = "USER@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            TramsAndConditions=true
        }) ;
    }
}
