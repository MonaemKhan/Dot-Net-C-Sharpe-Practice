using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForReact.DbCon;

namespace TestForReact.Controllers;

[Route("[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly DbConnectionContext _context;

    public CityController(DbConnectionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCity()
    {
        return Ok(await _context.CityTable.ToListAsync());
    }

    [HttpGet("CityByCountry")]
    public async Task<IActionResult> GetCityByCountry(int Id)
    {
        return Ok(await _context.CityTable.Where(x=>x.CountryId == Id).ToListAsync());
    }
}
