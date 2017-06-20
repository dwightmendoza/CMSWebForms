using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSUsersAndRoles.Models
{
    public class Inventory
    {
        [Key]
        //[ForeignKey("Products")]
        public int ProductId { get; set; }      
        public virtual Product Product { get; set; }
        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("doesSKUExist", "Inventories", HttpMethod = "POST", ErrorMessage = "SKU already exists. Please enter a different SKU.")]
        public string SKU { get; set; }
        
        public string Name { get; set; }

        public string Warehouse { get; set; }

        public string Location { get; set; }
        [Display(Name = "On Hand")]
        public int? OnHand { get; set; }
        [Display(Name = "On Order")]
        public int? OnOrder { get; set; }
        public int? Committed { get; set; }
        public int? Available { get; set; }
        public int? Minimum { get; set; }
        public int? EOQ { get; set; }
        public int? Maximum { get; set; }
        [Display(Name = "Std Cost")]
        public decimal? StdCost { get; set; }
        [Display(Name = "Avg Cost")]
        public decimal? AvgCost { get; set; }
        [Display(Name = "Last Cost")]
        public decimal? LastCost { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Inventory Date")]
        public DateTime? InventoryDate { get; set; }
       
    }
}