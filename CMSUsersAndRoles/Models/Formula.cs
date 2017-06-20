using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSUsersAndRoles.Models
{
    public class Formula
    {
        [Key]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }

    }
}