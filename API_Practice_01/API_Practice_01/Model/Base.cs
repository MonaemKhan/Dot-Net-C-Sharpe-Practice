using System.ComponentModel.DataAnnotations;

namespace API_Practice_01.Model
{
    public class Base
    {
        [Required]
        public DateTimeOffset? CreatedAt { get; set; }

        [Required]
        [MaxLength(20)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTimeOffset? UpdatedAt { get; set; }

        [Required]
        [MaxLength(20)]
        public string? UpdatedBy { get; set; }
    }
}
