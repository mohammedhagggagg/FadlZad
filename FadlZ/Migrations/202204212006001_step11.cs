namespace FadlZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Cat_ID = c.Int(nullable: false, identity: true),
                        Cat_Name = c.String(),
                        Cat_Des = c.String(),
                    })
                .PrimaryKey(t => t.Cat_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Pro_ID = c.String(nullable: false, maxLength: 128),
                        Pro_Name = c.String(),
                        Pro_Description = c.String(),
                        Pro_Type = c.String(),
                        Pro_Image = c.String(),
                        User_ID = c.String(maxLength: 128),
                        Cat_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pro_ID)
                .ForeignKey("dbo.Categories", t => t.Cat_ID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_ID)
                .Index(t => t.User_ID)
                .Index(t => t.Cat_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "User_ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Cat_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Cat_ID" });
            DropIndex("dbo.Products", new[] { "User_ID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
