using System.ComponentModel.DataAnnotations;

namespace API_Practice_01.Model
{
    public class Student:Base
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string? StudentRegNo { get; set; }

        [Required]
        [MaxLength(20)]
        public string? StudentName { get; set; }

        [Required]
        [MaxLength(20)]
        public string? StudentEmail { get; set; }

        [Required]
        [MaxLength(20)]
        public string? StudentPhone { get; set; }

        private IList<Thesis>? theses { get; set; }
    }
}
