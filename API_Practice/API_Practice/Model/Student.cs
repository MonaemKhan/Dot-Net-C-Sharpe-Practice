using System.ComponentModel.DataAnnotations;

namespace API_Practice.Model
{
    public class Student:Base
    {
        [Required][MaxLength(20)]
        public string FirstName { get; set; }

        [Required][MaxLength(20)]
        public string LastName { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        public DateTimeOffset Birthday { get; set;}

        [Required][MaxLength(20)]
        public string Department { get; set; }
    }
}
