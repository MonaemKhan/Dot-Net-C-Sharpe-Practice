using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MiniInventoryManagementSystem.Models
{
    public class Sales
    {
        [Key]
        [Required]
        [DisplayName("Sales Id")]
        public int SalesId { get; set; }

        [Required]
        [DisplayName("SalesMan's Name")]
        [ForeignKey("SalesManID")]
        [Column("SalesManID")]
        public SalesMan Sales_SalesMan { get; set; }

        [Required]
        [DisplayName("Customer's Name")]
        [ForeignKey("CustomerId")]
        [Column("CustomerId")]
        public Customer Sales_Customer { get; set; }

        [Required]
        [DisplayName("Sales Date")]
        [MaxLength(20)]
        public string SalesDate { get; set; }
    }
}
