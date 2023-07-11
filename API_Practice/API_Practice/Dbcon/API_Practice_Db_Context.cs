
using API_Practice.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Practice.Dbcon
{
    public class API_Practice_Db_Context : DbContext
    {
        public API_Practice_Db_Context(DbContextOptions<API_Practice_Db_Context> options):base(options)
        {
            
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Employee> employees { get; set; }


    }
}
