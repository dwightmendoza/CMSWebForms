using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMSUsersAndRoles.Models
{
    public class CMSWebFormsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CMSWebFormsContext() : base("name=CMSWebFormsContext")
        {
        }

        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.Formula> Formulae { get; set; }

        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.Ingredient> Ingredients { get; set; }

        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.Quote> Quotes { get; set; }

        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.QuoteDetail> QuoteDetails { get; set; }

        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<CMSUsersAndRoles.Models.OrderDetail> OrderDetails { get; set; }

    }
}
