namespace FShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Supplier_entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Suppliers", "CreatedBy", c => c.String());
            AddColumn("dbo.Suppliers", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Suppliers", "UpdateBy", c => c.String());
            AddColumn("dbo.Suppliers", "Status", c => c.Boolean());
            AddColumn("dbo.Suppliers", "MetaKeyword", c => c.String());
            AddColumn("dbo.Suppliers", "MetaDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "MetaDescription");
            DropColumn("dbo.Suppliers", "MetaKeyword");
            DropColumn("dbo.Suppliers", "Status");
            DropColumn("dbo.Suppliers", "UpdateBy");
            DropColumn("dbo.Suppliers", "UpdatedDate");
            DropColumn("dbo.Suppliers", "CreatedBy");
            DropColumn("dbo.Suppliers", "CreatedDate");
        }
    }
}
