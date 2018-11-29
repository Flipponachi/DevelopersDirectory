namespace DevelopersDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryTitle = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.CategoryTitle, unique: true);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        TwitterHandle = c.String(),
                        GithubId = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeveloperId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Developers", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Developers", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "CategoryTitle" });
            DropTable("dbo.Developers");
            DropTable("dbo.Categories");
        }
    }
}
