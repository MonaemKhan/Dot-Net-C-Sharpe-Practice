using Microsoft.EntityFrameworkCore;
using MVC_PROJECT_PRACTICE.Models;

namespace MVC_PROJECT_PRACTICE.DBCon
{
    public class DbConnectionContext:DbContext
    {
        public DbConnectionContext(DbContextOptions<DbConnectionContext> options):base(options)
        {
            
        }

        public DbSet<Student>? StudentDetails { get; set; }
        public DbSet<Teacher>? TeacherDetails { get; set; }

        public DbSet<Thesis>? ThesisDetails { get; set; }
    }
}
