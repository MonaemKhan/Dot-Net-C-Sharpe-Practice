using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PROJECT_PRACTICE.DBCon;
using MVC_PROJECT_PRACTICE.Models;

namespace MVC_PROJECT_PRACTICE.Controllers
{
    public class ThesisController : Controller
    {
        private readonly DbConnectionContext _context;
        public ThesisController(DbConnectionContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> ThesisIndex()
        {
            var data = await _context.ThesisDetails.Include(x=>x.Teacher).Include(x=>x.Student).ToListAsync();
            foreach(var item in data)
            {
                var teacher = await _context.TeacherDetails.FindAsync(item.ThesisTeacherId);
                item.Teacher = teacher;

                var student = await _context.StudentDetails.FindAsync(item.ThesisStudentId);
                item.Student = student;
            }
            return View(data);
        }

        public ActionResult ThesisCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ThesisCreate(Thesis thesis)
        {
            if (!ModelState.IsValid)
            {
                return View(thesis);
            }

            thesis.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow).ToString();
            thesis.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow).ToString();
            thesis.UpdatedBy = "Monaem";
            thesis.CreatedBy = "Monaem";

            await _context.ThesisDetails.AddAsync(thesis);
            await _context.SaveChangesAsync();
            return RedirectToAction("ThesisIndex");
        }
    }
}
