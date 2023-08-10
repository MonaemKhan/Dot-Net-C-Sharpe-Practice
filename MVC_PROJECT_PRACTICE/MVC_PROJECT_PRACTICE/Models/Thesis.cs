using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_PROJECT_PRACTICE.Models
{
    public class Thesis:Base
    {
        [Required]
        [MaxLength(20)]
        [Key]
        [Display(Name = "Thesis Id")]
        public string? ThesisID { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Thesis Name")]
        public string? ThesisName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Thesis Theacher")]
        [ForeignKey("TeacherId")]
        public string? ThesisTeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Thesis Student")]
        [ForeignKey("StudentRegNo")]
        public string? ThesisStudentId { get; set; }
        public Student? Student { get; set; }

    }
}
