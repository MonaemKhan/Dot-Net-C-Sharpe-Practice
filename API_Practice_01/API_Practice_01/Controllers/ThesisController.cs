using API_Practice_01.DbCon;
using API_Practice_01.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Practice_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThesisController : Controller
    {
        private readonly DbConnetionContext _context;

        public ThesisController(DbConnetionContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<Thesis> Post(Thesis thesisvalue)
        {
            thesisvalue.CreatedAt = DateTime.UtcNow;
            thesisvalue.CreatedBy = "_Monaem";
            thesisvalue.UpdatedAt = DateTime.UtcNow;
            thesisvalue.UpdatedBy = "_Monaem";
            _context.ThesisDetails.Add(thesisvalue);
            _context.SaveChanges();
            return Ok(thesisvalue);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thesis>>> get()
        {
            return await _context.ThesisDetails.Include(x => x.Teacher).ToListAsync();
        }
    }
}
