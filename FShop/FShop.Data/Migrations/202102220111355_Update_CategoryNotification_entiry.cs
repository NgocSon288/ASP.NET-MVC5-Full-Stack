namespace FShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_CategoryNotification_entiry : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CategoryNotifications", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryNotifications", "Status", c => c.Int(nullable: false));
        }
    }
}
