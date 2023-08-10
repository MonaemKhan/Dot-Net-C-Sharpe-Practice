using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_PROJECT_PRACTICE.Models
{
    public class Teacher:Base
    {
        [Required]
        [MaxLength(20)]
        [Key]
        [Display(Name = "Teacher ID")]
        public string? TeacherId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Full Name")]
        public string? TeacherName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Email")]
        public string? TeacherEmail { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Contact")]
        public string TeacherContact { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Faculty")]
        public string? TeacherFaculty { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Department")]
        public string? TeacherDepartment { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "JoiningDate")]
        public string? TeacherJoinDate { get; set; }
    }
}
