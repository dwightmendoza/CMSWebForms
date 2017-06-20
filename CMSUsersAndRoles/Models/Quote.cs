using CMSUsersAndRoles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSUsersAndRoles.Models
{
    public class Quote
    {
        public int QuoteId { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public List<QuoteDetail> QuoteDetail { get; set; }
        public string SalesRep { get; set; }
        public bool DeliveryAddressSame { get; set; }
        public string DeliveryAddressContact { get; set; }
        public string DeliveryAddressCompany { get; set; }
        public string DeliveryAddressStreet1 { get; set; }
        public string DeliveryAddressStreet2 { get; set; }
        public string DeliveryAddressCity { get; set; }
        public string DeliveryAddressState { get; set; }
        public string DeliveryAddressZip { get; set; }
        public string DeliveryAddressPhone { get; set; }
        public string DeliveryAddressAltPhone { get; set; }
        public string DeliveryAddressEmail { get; set; }
       // public decimal? Discount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime? QuoteDate { get; set; }
        public DateTime? QuoteSent { get; set; }
        public DateTime? GoodUntil { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateOrdered { get; set; }
        
    }
}