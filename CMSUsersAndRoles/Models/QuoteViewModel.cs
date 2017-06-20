using CMSUsersAndRoles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSUsersAndRoles.Models
{
    public class QuoteViewModel
    {   [Key]
        [Display(Name = "Quote Id")]
        public int QuoteId { get; set; }
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
        [StringLength(10)]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string PostalCode { get; set; }
        [Phone]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Phone]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Same as Company Address")]
        public bool DeliveryAddressSame { get; set; }
        [Required]
        [Display(Name = "Contact")]
        public string DeliveryAddressContact { get; set; }
       
        [Display(Name = "Company")]
        public string DeliveryAddressCompany { get; set; }
        [Required]
        [Display(Name = "Address 1")]
        public string DeliveryAddressStreet1 { get; set; }
        [Display(Name = "Address 2")]
        public string DeliveryAddressStreet2 { get; set; }
        [Required]
        [Display(Name = "City")]
        public string DeliveryAddressCity { get; set; }
        [Required]
        [Display(Name = "State")]
        public string DeliveryAddressState { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string DeliveryAddressZip { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string DeliveryAddressPhone { get; set; }
        [Phone]
        [Display(Name = "Alt Phone")]
        public string DeliveryAddressAltPhone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string DeliveryAddressEmail { get; set; }
        [Range(0, 100)]
        public decimal? Discount { get; set; }
        [Display(Name = "Payment Terms")]
        public int? PaymentTerms { get; set; }
        // Columns from QuoteDetail table
     
        [Display(Name = "Quote Detail")]
        public List<QuoteDetail> QuoteDetail { get; set; }
        // Columns from Quote table
        
        //public int QuoteId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Quote Date")]
        public DateTime? QuoteDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Good Until")]
        public DateTime? GoodUntil { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Quote Sent")]
        public DateTime? QuoteSent { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Approved")]
        public DateTime? DateApproved { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Ordered")]
        public DateTime? DateOrdered { get; set; }

    }
}