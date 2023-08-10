using ImageUploadRetrive.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageUploadRetrive.DBCon
{
    public class DbConnectionContext:DbContext
    {
        public DbConnectionContext(DbContextOptions<DbConnectionContext> option):base(option)
        {
            
        }
        public DbSet<Student>? Students { get; set; }
    }
}
