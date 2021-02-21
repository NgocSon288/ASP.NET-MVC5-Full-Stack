namespace FShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Advertisement_entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Advertisements", "CreatedBy", c => c.String());
            AddColumn("dbo.Advertisements", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Advertisements", "UpdateBy", c => c.String());
            AddColumn("dbo.Advertisements", "MetaKeyword", c => c.String());
            AddColumn("dbo.Advertisements", "MetaDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "MetaDescription");
            DropColumn("dbo.Advertisements", "MetaKeyword");
            DropColumn("dbo.Advertisements", "UpdateBy");
            DropColumn("dbo.Advertisements", "UpdatedDate");
            DropColumn("dbo.Advertisements", "CreatedBy");
            DropColumn("dbo.Advertisements", "CreatedDate");
        }
    }
}
