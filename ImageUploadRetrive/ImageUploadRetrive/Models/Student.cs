using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ImageUploadRetrive.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("Student Name")]
        [Required(ErrorMessage ="Name Requried")]
        public string? Name { get; set; }

        [DisplayName("Student Class")]
        [Required(ErrorMessage = "Class Requried")]
        public int Standard { get; set;}

        [DisplayName("Chosse Image")]
        [Required(ErrorMessage = "Image Location Requried")]
        public string? ImagePath { get; set;}

        public HttpPostedFileBase ImageFile { get; set;}
    }
}
