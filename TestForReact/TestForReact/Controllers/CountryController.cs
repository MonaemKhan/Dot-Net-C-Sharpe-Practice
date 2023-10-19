using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForReact.DbCon;

namespace TestForReact.Controllers;

[Route("[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly DbConnectionContext _context;

    public CountryController(DbConnectionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCountry()
    {
        return Ok(await _context.CountryTable.ToListAsync());
    }
}
