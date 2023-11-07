using Microsoft.EntityFrameworkCore;

namespace WEB_API_AUTH_Parctice.DBCon;

public class PracticeDbContext(DbContextOptions<PracticeDbContext> dbContextOption) : DbContext(dbContextOption)
{
    // this is needed if we want to custom configure of our model
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Get All The Configuration of DBContextClass
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PracticeDbContext).Assembly);
        // Set Key Behavior
        modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()).ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);
        
        base.OnModelCreating(modelBuilder);
    }
}
