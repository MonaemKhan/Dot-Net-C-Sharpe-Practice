using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Model;

[Table("StudentDetails")]
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
}
