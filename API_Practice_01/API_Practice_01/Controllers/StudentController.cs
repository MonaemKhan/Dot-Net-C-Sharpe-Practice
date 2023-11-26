using API_Practice_01.DbCon;
using API_Practice_01.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Net.Mime;

namespace API_Practice_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : Controller
    {
        private readonly DbConnetionContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(DbConnetionContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment= webHostEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> post(Student studentValue)
        {
            studentValue.CreatedAt = DateTime.UtcNow;
            studentValue.CreatedBy = "Monaem";
            studentValue.UpdatedAt = DateTime.UtcNow;
            studentValue.UpdatedBy = "Monaem";
            await _context.StudentDetails.AddAsync(studentValue);
            await _context.SaveChangesAsync();
            return Ok(studentValue);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> get()
        {
            return await _context.StudentDetails.ToListAsync();
        }

        [HttpGet("Reg:string")]
        public async Task<ActionResult<Student>> get(string regno)
        {
            return await _context.StudentDetails.FindAsync(regno);
        }

        [HttpPut]
        public ActionResult<Student> update(string regno,Student studentValue)
        {
            var _studentValue = _context.StudentDetails.Find(regno);
            if (_studentValue == null )
            {
                return Ok($"Student Reg No. {regno} is not Available");
            }

            _studentValue.UpdatedAt = DateTime.UtcNow;
            _studentValue.UpdatedBy = "Monaem Khan";
            _studentValue.StudentName = studentValue.StudentName;
            _studentValue.StudentPhone = studentValue.StudentPhone;
            _studentValue.StudentEmail  = studentValue.StudentEmail;
            _context.StudentDetails.Update(_studentValue);
            _context.SaveChanges();
            return Ok(_studentValue);
        }

        [HttpDelete]
        public ActionResult<Student> delete(string regno)
        {
            var ss = _context.StudentDetails.Find(regno);
            _context.StudentDetails.Remove(ss);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
