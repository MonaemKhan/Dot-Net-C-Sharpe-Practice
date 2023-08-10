using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PROJECT_PRACTICE.DBCon;
using MVC_PROJECT_PRACTICE.Models;
using System.Data;

namespace MVC_PROJECT_PRACTICE.Controllers
{
    public class StudentController : Controller
    {
        private readonly DbConnectionContext _context;
        public StudentController(DbConnectionContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> StudentIndex()
        {
            var data = await _context.StudentDetails.ToListAsync();
            return View(data);
        }

        public ActionResult StudentCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> StudentCreate(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            student.CreatedAt = DateTime.Now.ToString();
            student.UpdatedAt = DateTime.Now.ToString();
            student.UpdatedBy = "Monaem";
            student.CreatedBy = "Monaem";

            await _context.StudentDetails.AddAsync(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("StudentIndex");
        }

        //[Route("Student/StudentEdit/{Studen}")] // use this if route didn't Work
        public async Task<ActionResult> StudentEdit(string id) // define the variable name as id
        {
            var student = await _context.StudentDetails.FindAsync(id);
            if (student == null)
            {
                return RedirectToAction("StudentIndex");
            }
            return View(student);
        }

        [HttpPost]
        public async Task<ActionResult> StudentEdit(string id,Student student)
        {
            var _student = await _context.StudentDetails.FindAsync(id);
            if (_student == null)
            {
                return RedirectToAction("StudentIndex");
            }
            _student.StudentName = student.StudentName;
            _student.StudentEmail = student.StudentEmail;
            _student.StudentContact = student.StudentContact;
            _student.StudentVillage = student.StudentVillage;
            _student.StudentCity = student.StudentCity;
            _student.StudentDivision = student.StudentDivision;
            _student.StudentFaculty = student.StudentFaculty;
            _student.StudentDepartment = student.StudentDepartment;
            _student.StudentCredite = student.StudentCredite;
            _student.UpdatedAt = DateTime.Now.ToString();
            _student.UpdatedBy = "_Monaem";

            _context.Entry(_student).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return RedirectToAction("StudentIndex");
            }
            catch (DBConcurrencyException) { throw; }
        }

        public async Task<ActionResult> StudentDetails(string id)
        {
            var student = await _context.StudentDetails.FindAsync(id);
            return View(student);
        }

        public async Task<ActionResult> StudentDelete(string id)
        {
            var data = await _context.StudentDetails.FindAsync(id);
            _context.StudentDetails.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("StudentIndex");
        }
    }
}
