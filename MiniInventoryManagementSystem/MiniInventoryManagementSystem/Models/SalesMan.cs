using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MiniInventoryManagementSystem.Models
{
    public class SalesMan
    {
        [Key]
        [Required]
        [DisplayName("SalesMan Id")]
        public int SalesManId { get; set; }

        [Required]
        [DisplayName("SalesMan Name")]
        [MaxLength(20)]
        public string SalesManName { get; set; }

        [Required]
        [DisplayName("SalesMan Date Of Birth")]
        [MaxLength(20)]
        public string SalesManDOB { get; set; }

        [Required]
        [DisplayName("SalesMan Address")]
        [MaxLength(50)]
        public string SalesManAddress { get; set; }

        [Required]
        [DisplayName("SalesMan Designation")]
        [MaxLength(20)]
        public string SalesManDesignation { get; set; }

        [Required]
        [DisplayName("SalesMan Salary")]
        [MaxLength(20)]
        public string SalesManSalary { get; set; }

        [Required]
        [DisplayName("SalesMan Joining Date")]
        [MaxLength(20)]
        public string SalesManJoiningDate { get; set; }

        [Required]
        [DisplayName("SalesMan Phone Number")]
        [MaxLength(20)]
        public string SalesManPhone { get; set; }

        [Required]
        [DisplayName("SalesMan Email")]
        [MaxLength(20)]
        public string SalesManEmail { get; set; }
    }
}
