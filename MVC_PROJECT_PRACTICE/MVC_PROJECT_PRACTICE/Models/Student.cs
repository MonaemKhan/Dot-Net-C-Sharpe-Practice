using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT_PRACTICE.Models
{
    public class Student:Base
    {
        [Required]
        [MaxLength(20)]
        [Key]
        [Display(Name = "Registration No.")]
        public string? StudentRegNo { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Full Name")]
        public string? StudentName { get; set;}

        [Required]
        [MaxLength(50)]
        [Display(Name = "Email")]
        public string? StudentEmail { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Contact")]
        public string StudentContact { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Village")]
        public string StudentVillage { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "City")]
        public string? StudentCity { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Division")]
        public string? StudentDivision { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Faculty")]
        public string? StudentFaculty { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Department")]
        public string? StudentDepartment { get; set; }

        [Required]
        [Display(Name = "Total Credite")]
        public int StudentCredite { get; set; }
    }
}
