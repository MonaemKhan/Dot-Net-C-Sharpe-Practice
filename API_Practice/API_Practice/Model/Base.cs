using System.ComponentModel.DataAnnotations;

namespace API_Practice.Model
{
    public class Base
    {
        public int id { set; get; }

        [Required][MaxLength(20)]
        public string? Email { set; get; }

        [Required][MaxLength(20)]
        public string? Contact { set; get; }

        [Required]
        public int CreateBy { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }

        [Required]
        public int UpdateBy { get; set; }

        [Required]
        public DateTimeOffset UpdateDate { get; set; }
    }
}
