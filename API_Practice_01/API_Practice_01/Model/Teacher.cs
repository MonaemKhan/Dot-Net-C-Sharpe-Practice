using System.ComponentModel.DataAnnotations;

namespace API_Practice_01.Model
{
    public class Teacher:Base
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string? TecherRegNo { get; set; }

        [Required]
        [MaxLength(20)]
        public string? TecherName { get; set; }

        [Required]
        [MaxLength(20)]
        public string? TeacherEmail { get; set; }

        [Required]
        [MaxLength(20)]
        public string? TeacherPhone { get; set; }

        public IList<Thesis>? theses { get; set; }
    }
}
