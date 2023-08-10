using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniInventoryManagementSystem.Models
{
    public class PurchesDetails
    {
        [Key]
        [Required]
        [DisplayName("Purches Details Id")]
        public int PurchesDetailsId { get; set; }

        [Required]
        [DisplayName("Purches Id")]
        [ForeignKey("PurchesId")]
        [Column("PurchesId")]
        public Purches PurchesDetails_Purches { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [ForeignKey("ProductId")]
        [Column("ProductId")]
        public Product PurchesDetails_Product { get; set; }

        [Required]
        [DisplayName("Purches Details Price")]
        public double PurchesDetailsPrice { get; set; }

        [Required]
        [DisplayName("Purches Details Quantity")]
        public double PurchesDetailsQuantity { get; set; }
    }
}
