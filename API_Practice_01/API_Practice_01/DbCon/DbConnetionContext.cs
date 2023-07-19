using API_Practice_01.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Practice_01.DbCon
{
    public class DbConnetionContext:DbContext
    {
        public DbConnetionContext(DbContextOptions<DbConnetionContext> options):base(options)
        {
            
        }

        public DbSet<Student>? StudentDetails { get; set; }

        public DbSet<Teacher>? TeacherDetails { get; set; }

        public DbSet<Thesis>? ThesisDetails { get; set; }  
    }
}
