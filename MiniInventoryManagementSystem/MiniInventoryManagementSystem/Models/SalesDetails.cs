using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MiniInventoryManagementSystem.Models
{
    public class SalesDetails
    {
        [Key]
        [Required]
        [DisplayName("Sales Details Id")]
        public int SalesId { get; set; }

        [Required]
        [DisplayName("Sales Price")]
        public double DalesDetailsPrice { get; set; }

        [Required]
        [DisplayName("Sales Quantity")]
        public int DalesDetailsQuantity { get; set; }

        [Required]
        [DisplayName("Sales Id")]
        [ForeignKey("SalesId")]
        [Column("SalesId")]
        public Sales SalesDetails_Sales { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [ForeignKey("ProductId")]
        public Product SalesDetails_ProductId { get; set; }
    }
}
