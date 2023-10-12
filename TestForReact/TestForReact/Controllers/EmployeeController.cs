using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
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
    [HttpGet]
    public async Task<IActionResult> GetAllEmp()
    {
        return Ok(await _context.EMployeeTable.ToListAsync());
    }

    [HttpGet("Search:")]
    public async Task<IActionResult> GetEmpSer(string ser)
    {
        return Ok(await _context.EMployeeTable.Where(x=> x.Name.Contains(ser)).ToListAsync());
    }
}
