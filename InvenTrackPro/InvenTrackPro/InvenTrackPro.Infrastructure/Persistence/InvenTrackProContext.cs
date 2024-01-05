using InvenTrackPro.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel;

namespace InvenTrackPro.Infrastructure.Persistence;

public class InvenTrackProContext(DbContextOptions<InvenTrackProContext> options) : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
{

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if(_auditableEntitySaveChangesInterceptor is not null)
        //    optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInvenTrackProContext).Assembly);
        modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()).ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);
        base.OnModelCreating(modelBuilder);
    }
}