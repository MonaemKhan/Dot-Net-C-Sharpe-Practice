using System.ComponentModel.DataAnnotations;

namespace API_Practice_01.Model
{
    public class Thesis:Base
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string? ThesisId { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Teacher_RegNo { get; set; }
        public Teacher? Teacher { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Student_RegNo { get; set; }
        public Student? Student { get; set; }
    }
}
