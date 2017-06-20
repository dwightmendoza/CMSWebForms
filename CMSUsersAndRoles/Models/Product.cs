using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSUsersAndRoles.Models
{
    public enum ProductType
    {
        [Display(Name = "Acrylic Copolymer")]
        Acrylic_Copolymer,
        [Display(Name = "Albi Solvent")]
        Albi_Solvent,
        [Display(Name = "Albi Crete")]
        Albi_Crete,
        [Display(Name = "Albi DriClad")]
        Albi_DriClad,
        [Display(Name = "Albi Duraspray")]
        Albi_Duraspray,
        [Display(Name = "Albi Miscellaneous")]
        Albi_Misc,
        [Display(Name = "Albi Coating")]
        Albi_Coating,
        [Display(Name = "Albi PolyPrimer")]
        Albi_PolyPrimer,
        [Display(Name = "ClearCoat Solvent")]
        ClearCoat_Solvent,
        [Display(Name = "Industrial Coating")]
        Industrial_Coating,
        [Display(Name = "Fireproofing")]
        Fireproofing,
        [Display(Name = "Polymer")]
        Polymer,
        [Display(Name = "Raw Materials Albi")]
        Raw_Materials_Albi,
        [Display(Name = "Raw Materials Polymer")]
        Raw_Materials_Polymer,
        [Display(Name = "Raw Materials Specialty Coating")]
        Raw_Materials_SpecCoating,
        [Display(Name = "Raw Materials")]
        Raw_Materials,
        [Display(Name = "Solvent Copolymer")]
        Solvent_Copolymer,
        [Display(Name = "Specialty Coating")]
        Specialty_Coating,
        [Display(Name = "Styrene Acrylic Copolymer")]
        Styrene_Acrylic_Copolymer,
        [Display(Name = "Thinner")]
        Thinner,
        [Display(Name = "VA Copolymer")]
        VA_Copolymer,
        [Display(Name = "VA Homopolymer")]
        VA_Homopolymer,
        [Display(Name = "VA Maleate Ester Copolymer")]
        VA_Maleate_Ester_Copolymer,
        [Display(Name = "Vinyl Dispersion Epoxy")]
        Vinyl_Dispersion_Epoxy
    }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("doesSKUExist", "Products", HttpMethod = "POST", ErrorMessage = "SKU already exists. Please enter a different SKU.")]
        public string SKU { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public ProductType ProductType { get; set; }
        [Required(ErrorMessage = "Please make a selection")]
        [Display(Name = "Unit of Measure")]
        public UnitOfMeasure? UnitOfMeasure { get; set; }
        [Required]
        [Display(Name = "Sales Quantity")]
        public string SalesQuantity { get; set; }
        [Required]
        public string Container { get; set; }
        [Required]
        public bool Hazardous { get; set; }
        [Required]
        public string Warehouse { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }


    }
}