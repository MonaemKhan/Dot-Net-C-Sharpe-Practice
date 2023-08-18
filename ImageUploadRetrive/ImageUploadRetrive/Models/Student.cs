using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ImageUploadRetrive.Models
{
    public class Student
    {
            [Key]
            public int ImageId { get; set; }

            [Column(TypeName = "nvarchar(50)")]
            public string? Title { get; set; }

            [Column(TypeName = "nvarchar(100)")]
            [DisplayName("Image Name")]
            public string? ImageName { get; set; }

            [NotMapped]
            [DisplayName("Upload File")]
            public IFormFile? ImageFile { get; set; }
    }
}
