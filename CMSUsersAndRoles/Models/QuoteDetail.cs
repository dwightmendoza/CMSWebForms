using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMSUsersAndRoles.Models
{
    public class QuoteDetail
    {
        [Key]
        [Column(Order = 1)]
        public int QuoteId { get; set; }
        public virtual Quote Quote { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        [Column(Order = 2)]
        public int QuoteDetailId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public int Amount { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
    }
}