using Microsoft.EntityFrameworkCore;
using test.Model;

namespace test.dbcon;

public class dbconnectioncontext:DbContext
{
    public dbconnectioncontext(DbContextOptions<dbconnectioncontext> options):base(options)
    {
        
    }

    public DbSet<Student> StudentTable { get; set; }
    public DbSet<studentteacherview> Studentteacherviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // this has been added to get view
        modelBuilder
           .Entity<studentteacherview>()
           .ToView("StudentTeacherView")
           .HasKey(t => t.StudentName);
    }
}
