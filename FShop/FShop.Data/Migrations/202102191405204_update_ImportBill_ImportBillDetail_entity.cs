namespace FShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_ImportBill_ImportBillDetail_entity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImportBills", "Supplier_ID", "dbo.Suppliers");
            DropIndex("dbo.ImportBills", new[] { "Supplier_ID" });
            DropColumn("dbo.ImportBills", "Supplier_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImportBills", "Supplier_ID", c => c.Int());
            CreateIndex("dbo.ImportBills", "Supplier_ID");
            AddForeignKey("dbo.ImportBills", "Supplier_ID", "dbo.Suppliers", "ID");
        }
    }
}
