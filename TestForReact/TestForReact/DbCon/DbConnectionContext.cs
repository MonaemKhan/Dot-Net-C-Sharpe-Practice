using Microsoft.EntityFrameworkCore;
using TestForReact.Model;

namespace TestForReact.DbCon;

public class DbConnectionContext:DbContext
{
    public DbConnectionContext(DbContextOptions<DbConnectionContext> option):base(option)
    {
        
    }

    public DbSet<Employee> EMployeeTable { get; set; }
    public DbSet<Country> CountryTable { get; set; }
    public DbSet<City> CityTable { get; set; }
}
