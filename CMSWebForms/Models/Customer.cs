using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSWebForms.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string MI { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Title")]
        public string JobTitle { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [StringLength(10)]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [Phone]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Phone]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Phone]
        public string Fax { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Web { get; set; }
        [Range(0, 100,
            ErrorMessage = "Discount must be between 0 and 100")]
        public decimal Discount { get; set; }
        [Range(0, 360,
            ErrorMessage = "Payment terms must be between 0 and 360")]
        [Display(Name = "Payment Terms")]
        public int PaymentTerms { get; set; }

    }
}