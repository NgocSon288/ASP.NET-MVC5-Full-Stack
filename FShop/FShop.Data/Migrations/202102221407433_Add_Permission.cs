namespace FShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Permission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryMembers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PermissionCategoryMembers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryMemberID = c.Int(nullable: false),
                        PermissionID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CategoryMembers", t => t.CategoryMemberID, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.PermissionID, cascadeDelete: true)
                .Index(t => t.CategoryMemberID)
                .Index(t => t.PermissionID);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Members", "CategoryMember_ID", c => c.Int());
            CreateIndex("dbo.Members", "CategoryMember_ID");
            AddForeignKey("dbo.Members", "CategoryMember_ID", "dbo.CategoryMembers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermissionCategoryMembers", "PermissionID", "dbo.Permissions");
            DropForeignKey("dbo.PermissionCategoryMembers", "CategoryMemberID", "dbo.CategoryMembers");
            DropForeignKey("dbo.Members", "CategoryMember_ID", "dbo.CategoryMembers");
            DropIndex("dbo.PermissionCategoryMembers", new[] { "PermissionID" });
            DropIndex("dbo.PermissionCategoryMembers", new[] { "CategoryMemberID" });
            DropIndex("dbo.Members", new[] { "CategoryMember_ID" });
            DropColumn("dbo.Members", "CategoryMember_ID");
            DropTable("dbo.Permissions");
            DropTable("dbo.PermissionCategoryMembers");
            DropTable("dbo.CategoryMembers");
        }
    }
}
