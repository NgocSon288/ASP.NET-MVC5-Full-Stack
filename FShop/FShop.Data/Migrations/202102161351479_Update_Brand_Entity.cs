namespace FShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Brand_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Brands", "CreatedBy", c => c.String());
            AddColumn("dbo.Brands", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Brands", "UpdateBy", c => c.String());
            AddColumn("dbo.Brands", "Status", c => c.Boolean());
            AddColumn("dbo.Brands", "MetaKeyword", c => c.String());
            AddColumn("dbo.Brands", "MetaDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "MetaDescription");
            DropColumn("dbo.Brands", "MetaKeyword");
            DropColumn("dbo.Brands", "Status");
            DropColumn("dbo.Brands", "UpdateBy");
            DropColumn("dbo.Brands", "UpdatedDate");
            DropColumn("dbo.Brands", "CreatedBy");
            DropColumn("dbo.Brands", "CreatedDate");
        }
    }
}
