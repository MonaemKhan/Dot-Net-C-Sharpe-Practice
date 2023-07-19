using API_Practice_01.DbCon;
using API_Practice_01.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Practice_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly DbConnetionContext _context;

        public TeacherController(DbConnetionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> post(Teacher teachervalue)
        {
            teachervalue.CreatedAt = DateTime.UtcNow;
            teachervalue.CreatedBy = "_Monaem_";
            teachervalue.UpdatedAt = DateTime.UtcNow;
            teachervalue.UpdatedBy = "_Monaem_";
            await _context.TeacherDetails.AddAsync(teachervalue);
            await _context.SaveChangesAsync();
            return Ok(teachervalue);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> get()
        {
            return await _context.TeacherDetails.ToListAsync();
        }

        [HttpGet("Reg:string")]
        public async Task<ActionResult<Teacher>> get(string regno)
        {
            return await _context.TeacherDetails.FindAsync(regno);
        }

        [HttpPut]
        public ActionResult<Teacher> update(string regno, Teacher teachervalue)
        {
            var _teachervalue = _context.TeacherDetails.Find(regno);
            if (_teachervalue == null)
            {
                return Ok($"Student Reg No. {regno} is not Available");
            }

            _teachervalue.UpdatedAt = DateTime.UtcNow;
            _teachervalue.UpdatedBy = "Monaem Khan";
            _teachervalue.TecherName = teachervalue.TecherName;
            _teachervalue.TeacherPhone = teachervalue.TeacherPhone;
            _teachervalue.TeacherEmail = teachervalue.TeacherEmail;
            _context.TeacherDetails.Update(_teachervalue);
            _context.SaveChanges();
            return Ok(_teachervalue);
        }

        [HttpDelete]
        public ActionResult<Teacher> delete(string regno)
        {
            var ss = _context.TeacherDetails.Find(regno);
            _context.TeacherDetails.Remove(ss);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
