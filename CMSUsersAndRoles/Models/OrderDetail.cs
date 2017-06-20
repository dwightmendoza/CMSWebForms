using System.ComponentModel.DataAnnotations;

namespace CMSUsersAndRoles.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [Required]        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")] 
        public int Amount { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
    }
}