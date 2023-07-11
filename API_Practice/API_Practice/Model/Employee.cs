using System.ComponentModel.DataAnnotations;

namespace API_Practice.Model
{
    public class Employee:Base
    {
        [Required][MaxLength(20)]
        public string fullName { get; set; }

        [Required][MaxLength(20)]
        public string Designation { get; set; }
    }
}
