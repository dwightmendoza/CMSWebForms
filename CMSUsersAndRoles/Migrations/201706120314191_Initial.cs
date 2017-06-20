namespace CMSUsersAndRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        SalesRep = c.String(nullable: false),
                        Company = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MI = c.String(),
                        LastName = c.String(nullable: false),
                        JobTitle = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(),
                        WorkPhone = c.String(),
                        CellPhone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Web = c.String(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        PaymentTerms = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Formulae",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        SKU = c.String(),
                        Name = c.String(),
                        Instructions = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.IngredientId })
                .ForeignKey("dbo.Formulae", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        SKU = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ProductType = c.Int(nullable: false),
                        UnitOfMeasure = c.Int(nullable: false),
                        SalesQuantity = c.String(nullable: false),
                        Container = c.String(nullable: false),
                        Hazardous = c.Boolean(nullable: false),
                        Warehouse = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId)
                .Index(t => t.SKU, unique: true);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        SKU = c.String(nullable: false, maxLength: 50),
                        Name = c.String(),
                        Warehouse = c.String(),
                        Location = c.String(),
                        OnHand = c.Int(),
                        OnOrder = c.Int(),
                        Committed = c.Int(),
                        Available = c.Int(),
                        Minimum = c.Int(),
                        EOQ = c.Int(),
                        Maximum = c.Int(),
                        StdCost = c.Decimal(precision: 18, scale: 2),
                        AvgCost = c.Decimal(precision: 18, scale: 2),
                        LastCost = c.Decimal(precision: 18, scale: 2),
                        InventoryDate = c.DateTime(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.SKU, unique: true)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        SKU = c.String(),
                        ProductName = c.String(),
                        Amount = c.Int(nullable: false),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        QuoteId = c.Int(),
                        OrderStatus = c.Int(nullable: false),
                        OrderStatusString = c.String(),
                        PONumber = c.String(),
                        PODate = c.DateTime(),
                        SalesRep = c.String(),
                        BillingAddressSame = c.Boolean(nullable: false),
                        BillingAddressContact = c.String(),
                        BillingAddressCompany = c.String(),
                        BillingAddressStreet1 = c.String(),
                        BillingAddressStreet2 = c.String(),
                        BillingAddressCity = c.String(),
                        BillingAddressState = c.String(),
                        BillingAddressZip = c.String(),
                        BillingAddressPhone = c.String(),
                        BillingAddressAltPhone = c.String(),
                        BillingAddressEmail = c.String(),
                        ShippingAddressSame = c.Boolean(nullable: false),
                        ShippingAddressContact = c.String(),
                        ShippingAddressCompany = c.String(),
                        ShippingAddressStreet1 = c.String(),
                        ShippingAddressStreet2 = c.String(),
                        ShippingAddressCity = c.String(),
                        ShippingAddressState = c.String(),
                        ShippingAddressZip = c.String(),
                        ShippingAddressPhone = c.String(),
                        ShippingAddressAltPhone = c.String(),
                        ShippingAddressEmail = c.String(),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        DateRequested = c.DateTime(),
                        DateFulfilled = c.DateTime(),
                        DateShipped = c.DateTime(),
                        ShipMethod = c.String(),
                        PaymentTerms = c.Int(),
                        FOB = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Quotes", t => t.QuoteId)
                .Index(t => t.CustomerId)
                .Index(t => t.QuoteId);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        QuoteId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        SalesRep = c.String(),
                        DeliveryAddressSame = c.Boolean(nullable: false),
                        DeliveryAddressContact = c.String(),
                        DeliveryAddressCompany = c.String(),
                        DeliveryAddressStreet1 = c.String(),
                        DeliveryAddressStreet2 = c.String(),
                        DeliveryAddressCity = c.String(),
                        DeliveryAddressState = c.String(),
                        DeliveryAddressZip = c.String(),
                        DeliveryAddressPhone = c.String(),
                        DeliveryAddressAltPhone = c.String(),
                        DeliveryAddressEmail = c.String(),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuoteDate = c.DateTime(),
                        QuoteSent = c.DateTime(),
                        GoodUntil = c.DateTime(),
                        DateApproved = c.DateTime(),
                        DateOrdered = c.DateTime(),
                    })
                .PrimaryKey(t => t.QuoteId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.QuoteDetails",
                c => new
                    {
                        QuoteId = c.Int(nullable: false),
                        QuoteDetailId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SKU = c.String(),
                        ProductName = c.String(),
                        Amount = c.Int(nullable: false),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.QuoteId, t.QuoteDetailId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Quotes", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.QuoteId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.QuoteDetails", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.QuoteDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Quotes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Inventories", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Formulae", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Ingredients", "ProductId", "dbo.Formulae");
            DropIndex("dbo.QuoteDetails", new[] { "ProductId" });
            DropIndex("dbo.QuoteDetails", new[] { "QuoteId" });
            DropIndex("dbo.Quotes", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "QuoteId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Inventories", new[] { "Product_ProductId" });
            DropIndex("dbo.Inventories", new[] { "SKU" });
            DropIndex("dbo.Products", new[] { "SKU" });
            DropIndex("dbo.Ingredients", new[] { "ProductId" });
            DropIndex("dbo.Formulae", new[] { "Product_ProductId" });
            DropTable("dbo.QuoteDetails");
            DropTable("dbo.Quotes");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Inventories");
            DropTable("dbo.Products");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Formulae");
            DropTable("dbo.Customers");
        }
    }
}
