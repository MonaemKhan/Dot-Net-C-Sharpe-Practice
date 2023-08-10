using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PROJECT_PRACTICE.DBCon;
using MVC_PROJECT_PRACTICE.Models;

namespace MVC_PROJECT_PRACTICE.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DbConnectionContext _context;
        public TeacherController(DbConnectionContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> TeacherIndex()
        {
            var data = await _context.TeacherDetails.ToListAsync();
            return View(data);
        }

        public ActionResult TeacherCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> TeacherCreate(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            teacher.CreatedAt = DateTime.Now.ToString();
            teacher.UpdatedAt = DateTime.Now.ToString();
            teacher.UpdatedBy = "Monaem";
            teacher.CreatedBy = "Monaem";

            await _context.TeacherDetails.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("TeacherIndex");
        }
    }
}
