namespace FShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Logo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryNotifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                        Color = c.String(nullable: false),
                        Icon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LikeCount = c.Int(nullable: false),
                        DislikeCount = c.Int(nullable: false),
                        StarNumber = c.Int(nullable: false),
                        Reason = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false, maxLength: 500),
                        PostImage = c.String(),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdateBy = c.String(),
                        Status = c.Boolean(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Members", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        PassWord = c.String(nullable: false, maxLength: 100),
                        DisplayName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        Avatar = c.String(nullable: false),
                        IsAnotherIdentity = c.String(),
                        MemberStatusID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdateBy = c.String(),
                        Status = c.Boolean(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MemberStatuses", t => t.MemberStatusID, cascadeDelete: true)
                .Index(t => t.MemberStatusID);
            
            CreateTable(
                "dbo.MemberStatuses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 100, unicode: false),
                        Image = c.String(nullable: false),
                        MoreImage = c.String(nullable: false, storeType: "xml"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Promotion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        IsFreeShip = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        IsInstallment = c.Boolean(nullable: false),
                        Rating = c.Single(nullable: false),
                        BuyCount = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdateBy = c.String(),
                        Status = c.Boolean(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategorys", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.BrandID)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategorys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(nullable: false),
                        Icon = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdateBy = c.String(),
                        Status = c.Boolean(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ImportBillDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImportPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        ImportBillID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ImportBills", t => t.ImportBillID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ImportBillID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ImportBills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdateBy = c.String(),
                        Status = c.Boolean(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.MemberNotifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        NotificationID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdateBy = c.String(),
                        Status = c.Boolean(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Notifications", t => t.NotificationID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.NotificationID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 500),
                        CategoryNotificationID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdateBy = c.String(),
                        Status = c.Boolean(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CategoryNotifications", t => t.CategoryNotificationID, cascadeDelete: true)
                .Index(t => t.CategoryNotificationID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        CustomerAddress = c.String(nullable: false, maxLength: 500),
                        CustomerEmail = c.String(nullable: false, maxLength: 100),
                        CustomerMobile = c.String(nullable: false),
                        CustomerMessage = c.String(),
                        PaymentMethodID = c.Int(),
                        MemberID = c.Int(),
                        OrderStatusID = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdateBy = c.String(),
                        Status = c.Boolean(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Members", t => t.MemberID)
                .ForeignKey("dbo.OrderStatuses", t => t.OrderStatusID)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodID)
                .Index(t => t.PaymentMethodID)
                .Index(t => t.MemberID)
                .Index(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.OrderStatuses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Image = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatuses");
            DropForeignKey("dbo.Orders", "MemberID", "dbo.Members");
            DropForeignKey("dbo.MemberNotifications", "NotificationID", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "CategoryNotificationID", "dbo.CategoryNotifications");
            DropForeignKey("dbo.MemberNotifications", "MemberID", "dbo.Members");
            DropForeignKey("dbo.ImportBillDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ImportBillDetails", "ImportBillID", "dbo.ImportBills");
            DropForeignKey("dbo.ImportBills", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.Comments", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategorys");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Comments", "CustomerID", "dbo.Members");
            DropForeignKey("dbo.Members", "MemberStatusID", "dbo.MemberStatuses");
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Orders", new[] { "MemberID" });
            DropIndex("dbo.Orders", new[] { "PaymentMethodID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Notifications", new[] { "CategoryNotificationID" });
            DropIndex("dbo.MemberNotifications", new[] { "NotificationID" });
            DropIndex("dbo.MemberNotifications", new[] { "MemberID" });
            DropIndex("dbo.ImportBills", new[] { "Supplier_ID" });
            DropIndex("dbo.ImportBillDetails", new[] { "ProductID" });
            DropIndex("dbo.ImportBillDetails", new[] { "ImportBillID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Members", new[] { "MemberStatusID" });
            DropIndex("dbo.Comments", new[] { "ProductID" });
            DropIndex("dbo.Comments", new[] { "CustomerID" });
            DropTable("dbo.Slides");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.OrderStatuses");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Notifications");
            DropTable("dbo.MemberNotifications");
            DropTable("dbo.ImportBills");
            DropTable("dbo.ImportBillDetails");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductCategorys");
            DropTable("dbo.Products");
            DropTable("dbo.MemberStatuses");
            DropTable("dbo.Members");
            DropTable("dbo.Comments");
            DropTable("dbo.CategoryNotifications");
            DropTable("dbo.Brands");
            DropTable("dbo.Advertisements");
        }
    }
}
