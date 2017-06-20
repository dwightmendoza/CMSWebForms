using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSUsersAndRoles.Models
{
    public class OrderViewModel
    {
        [Key]
        [Display(Name = "Order No.")]
        public int OrderId { get; set; }
        // Columns from Customer table
        [Required(ErrorMessage = "Please select a company")]
        [Display(Name = "Customer Id")]
        public int? CustomerId { get; set; }
        [Display(Name = "Sales Rep")]
        public string SalesRep { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Company { get; set; }
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }
        [Phone]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Phone]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //Columns from Order table
        [Required(ErrorMessage = "Order Status is required")]
        [Display(Name = "Status")]
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusString { get; set; }
        [Display(Name = "Quote No.")]
        public int QuoteId { get; set; }
       // public virtual Quote Quote { get; set; }
        [Display(Name = "PO Number")]
        public string PONumber { get; set; }
        [Display(Name = "PO Date")]
        public DateTime? PODate { get; set; }
        
        [Display(Name = "Same as Company Address")]
        public bool BillingAddressSame { get; set; }
        [Required]
        [Display(Name = "Billing Contact")]
        public string BillingAddressContact { get; set; }
        [Required]
        [Display(Name = "Billing Company")]
        public string BillingAddressCompany { get; set; }
        [Required]
        [Display(Name = "Billing Address 1")]
        public string BillingAddressStreet1 { get; set; }
        [Display(Name = "Billing Address 2")]
        public string BillingAddressStreet2 { get; set; }
        [Required]
        [Display(Name = "Billing City")]
        public string BillingAddressCity { get; set; }
        [Required]
        [Display(Name = "Billing State")]
        public string BillingAddressState { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Billing Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string BillingAddressZip { get; set; }
        [Display(Name = "Billing Phone")]
        public string BillingAddressPhone { get; set; }
        [Display(Name = "Billing Alt. Phone")]
        public string BillingAddressAltPhone { get; set; }
        [Display(Name = "Billing Email")]
        public string BillingAddressEmail { get; set; }
        [Display(Name = "Same as Billing Address")]
        public bool ShippingAddressSame { get; set; }
        [Required]
        [Display(Name = "Shipping Contact")]
        public string ShippingAddressContact { get; set; }
        [Required]
        [Display(Name = "Shipping Company")]
        public string ShippingAddressCompany { get; set; }
        [Required]
        [Display(Name = "Shipping Address 1")]
        public string ShippingAddressStreet1 { get; set; }
        [Display(Name = "Shipping Address 2")]
        public string ShippingAddressStreet2 { get; set; }
        [Required]
        [Display(Name = "Shipping City")]
        public string ShippingAddressCity { get; set; }
        [Required]
        [Display(Name = "Shipping State")]
        public string ShippingAddressState { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Shipping Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string ShippingAddressZip { get; set; }
        [Display(Name = "Shipping Phone")]
        public string ShippingAddressPhone { get; set; }
        [Display(Name = "Shipping Alt. Phone")]
        public string ShippingAddressAltPhone { get; set; }
        [Display(Name = "Shipping Email")]
        public string ShippingAddressEmail { get; set; }
        [Required]
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        [Display(Name = "Shipping Cost")]
        public decimal ShippingCost { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Requested")]
        public DateTime? DateRequested { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Fulfilled")]
        public DateTime? DateFulfilled { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Shipped")]
        public DateTime? DateShipped { get; set; }
        [Display(Name = "Shipping Method")]
        public string ShipMethod { get; set; }
        [Display(Name = "Payment Terms")]
        public int? PaymentTerms { get; set; }
        public string FOB { get; set; }
        public string Notes { get; set; }
        //from OrderDetail table
        public List<OrderDetail> OrderDetail { get; set; }

    }
}