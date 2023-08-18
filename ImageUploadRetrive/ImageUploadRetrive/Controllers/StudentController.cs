using ImageUploadRetrive.DBCon;
using ImageUploadRetrive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ImageUploadRetrive.Controllers
{
    public class StudentController : Controller
    {
        private readonly DbConnectionContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public StudentController(DbConnectionContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;

        }
        public async Task<ActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student imageModel)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath; //it get the project environment
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName); //it get the file name from the input
                string extension = Path.GetExtension(imageModel.ImageFile.FileName); // it get extention name of the file
                imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension; // set iamge name as new
                string path = Path.Combine(wwwRootPath + "/images/", fileName); // combine path, where to save the images
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream); // now copy the images into the selected folder
                }
                //Insert record
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }


        public async Task<ActionResult> Edit(int Id)
        {
            var data = await _context.Students.FindAsync(Id);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var imagepath = Path.Combine(_hostEnvironment.WebRootPath+ "/images/"+ student.ImageName);
                if(System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }
                string fileName = Path.GetFileNameWithoutExtension(student.ImageFile.FileName);
                string extention = Path.GetExtension(student.ImageFile.FileName);
                student.ImageName = fileName = fileName + "-xyz"+ extention;
                string path = Path.Combine(_hostEnvironment.WebRootPath+ "/images/"+ fileName);
                using (var filestrem = new FileStream(path, FileMode.Create))
                {
                    await student.ImageFile.CopyToAsync(filestrem);
                }
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public async Task<ActionResult> Delete(int id)
        {
            return View(await _context.Students.FindAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Student student)
        {
            var imagepath = Path.Combine(_hostEnvironment.WebRootPath + "/images/" + student.ImageName);
            if (System.IO.File.Exists(imagepath))
            {
                System.IO.File.Delete(imagepath);
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
