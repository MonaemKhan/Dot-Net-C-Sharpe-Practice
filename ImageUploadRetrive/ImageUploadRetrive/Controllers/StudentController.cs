using ImageUploadRetrive.DBCon;
using ImageUploadRetrive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageUploadRetrive.Controllers
{
    public class StudentController : Controller
    {
        private readonly DbConnectionContext _context;
        public StudentController(DbConnectionContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student employee, IFormFile pictureFile)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            if (pictureFile.Length > 0)
            {
                var fileName = pictureFile.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (FileStream file = new(path, FileMode.Create))
                {
                    await pictureFile.CopyToAsync(file);
                }

                employee.ImagePath = fileName;
            }

            await _context.Stu.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Index()
        {
            var data = await _context.Students.ToListAsync();
            return View(data);
        }
    }
}
