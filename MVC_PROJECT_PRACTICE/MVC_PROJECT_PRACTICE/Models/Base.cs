using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT_PRACTICE.Models
{
    public class Base
    {
        [MaxLength(50)]
        public string? CreatedAt { get; set; }

        [MaxLength(50)]
        public string? UpdatedAt { get; set;}

        [MaxLength(10)]
        public string? CreatedBy { get; set;}

        [MaxLength(10)]
        public string? UpdatedBy { get; set;}
    }
}
