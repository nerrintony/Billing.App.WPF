using System.ComponentModel.DataAnnotations;

namespace Test.ShopBilling.WPFApp.Models
{
    public class Product
    {
        public Guid ProductId { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        [Range(0.01, 999999)]
        public decimal ProductPrice { get; set; }
        [Range(0, int.MaxValue)]
        public int ProductQuantity { get; set; }
        [Required]
        public DateTime CreatedDate{ get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
