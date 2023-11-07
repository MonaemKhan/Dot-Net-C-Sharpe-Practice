using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WEB_API_AUTH_Parctice.DBCon;

public class AuthDbContext : IdentityDbContext // IdentityDbContext used here as it is not an normal database
{
    public AuthDbContext(DbContextOptions<AuthDbContext> option):base(option)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var readerRoleId = "7359509a-b2c4-41d1-a04f-65f0f5f8c220";
        var writerRoleId = "7865c99f-f172-4371-8a22-e7aa4d3e9ffb";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = readerRoleId,
                ConcurrencyStamp = DateTime.UtcNow.ToString(),
                Name = "Reader",
                NormalizedName = "reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerRoleId,
                ConcurrencyStamp = DateTime.UtcNow.ToString(),
                Name = "Writer",
                NormalizedName = "writer".ToUpper()
            }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}