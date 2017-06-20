using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSUsersAndRoles.Models
{
    public enum OrderStatus
    {
        Pending = 1,
        Held = 2,
        [Display(Name = "In Process")]
        In_Process = 3,
        Completed = 4,
        Shipped = 5,
        Returned = 6,
        Cancelled = 7
    }
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int? QuoteId { get; set; }
        public virtual Quote Quote { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusString { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public string PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public string SalesRep { get; set; }
        public bool BillingAddressSame { get; set; }
        public string BillingAddressContact { get; set; }
        public string BillingAddressCompany { get; set; }
        public string BillingAddressStreet1 { get; set; }
        public string BillingAddressStreet2 { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressState { get; set; }
        public string BillingAddressZip { get; set; }
        public string BillingAddressPhone { get; set; }
        public string BillingAddressAltPhone { get; set; }
        public string BillingAddressEmail { get; set; }
        public bool ShippingAddressSame { get; set; }
        public string ShippingAddressContact { get; set; }
        public string ShippingAddressCompany { get; set; }
        public string ShippingAddressStreet1 { get; set; }
        public string ShippingAddressStreet2 { get; set; }
        public string ShippingAddressCity { get; set; }
        public string ShippingAddressState { get; set; }
        public string ShippingAddressZip { get; set; }
        public string ShippingAddressPhone { get; set; }
        public string ShippingAddressAltPhone { get; set; }
        public string ShippingAddressEmail { get; set; }
        [Required]
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingCost { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public DateTime? OrderDate { get; set; }
        public DateTime? DateRequested { get; set; }
        public DateTime? DateFulfilled { get; set; }
        public DateTime? DateShipped { get; set; }
        public string ShipMethod { get; set; }
        public int? PaymentTerms { get; set; }
        public string FOB { get; set; }
        public string Notes { get; set; }

    }
}
