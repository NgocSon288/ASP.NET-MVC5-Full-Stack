namespace FShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_product_entity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "MoreImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "MoreImage", c => c.String(nullable: false, storeType: "xml"));
        }
    }
}
