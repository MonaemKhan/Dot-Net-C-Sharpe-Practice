using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForReact.DbCon;
using TestForReact.Model;

namespace TestForReact.Controllers;

[Route("/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly DbConnectionContext _context;

    public EmployeeController(DbConnectionContext context)
    {
        _context = context;
    }
    [HttpGet("Id")]
    public async Task<IActionResult> GetEmp(int Id)
    {
        var data = await _context.EMployeeTable.Where(x=>x.Id.Equals(Id)).Include(x => x.Country).Include(x => x.City).ToListAsync();
        return Ok(data[0]);
    }

    [HttpGet("SearchIndexPage")]
    public async Task<IActionResult> GetEmpSer(int index, int page,string ser)
    {
        var data = await _context.EMployeeTable.Where(x => x.Name.Contains(ser)).Include(x => x.Country).Include(x => x.City).ToListAsync();
        int total = data.Count;
        int start = page * index;
        int end = (page * index) + index;
        if (end > data.Count)
        {
            end = data.Count;
        }


        List<Employee> employees = new List<Employee>();

        for (int i = start; i < end; i++)
        {
            employees.Add(data[i]);
        }

        return Ok(new
        {
            data = employees,
            total = total
        });

    }

    [HttpGet("Index&PageNum")]
    public async Task<IActionResult> GetEmp(int index = 5, int page = 0)
    {
        var data = await _context.EMployeeTable.Include(x => x.Country).Include(x => x.City).ToListAsync();

        int total = data.Count;
        int start = page*index;
        int end = (page*index)+index;
        if (end > data.Count)
        {
            end = data.Count;
        }

        
        List<Employee> employees = new List<Employee>();

            for (int i = start; i < end; i++)
            {
                employees.Add(data[i]);
            }

        return Ok(new
        {
            data = employees,
            total = total
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(Employee emp)
    {
        await _context.EMployeeTable.AddAsync(emp);
        await _context.SaveChangesAsync();
        return Ok(emp);
    }

    [HttpPut]
    public async Task<IActionResult> EditEmployee(Employee emp)
    {
        _context.EMployeeTable.Update(emp);
        await _context.SaveChangesAsync();
        return Ok(emp);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmp(int Id)
    {
        _context.EMployeeTable.Remove(await _context.EMployeeTable.FindAsync(Id));
        await _context.SaveChangesAsync();
        return Ok(Id);
    }
}
