namespace FadlZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "Pro_ID", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "User_ID", "dbo.AspNetUsers");
            DropIndex("dbo.Feedbacks", new[] { "Pro_ID" });
            DropIndex("dbo.Feedbacks", new[] { "User_ID" });
            AddColumn("dbo.Feedbacks", "ProductName", c => c.String(nullable: false));
            AddColumn("dbo.Feedbacks", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Pro_Image", c => c.String());
            DropColumn("dbo.Feedbacks", "Pro_ID");
            DropColumn("dbo.Feedbacks", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "User_ID", c => c.String(maxLength: 128));
            AddColumn("dbo.Feedbacks", "Pro_ID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "Pro_Image", c => c.String(nullable: false));
            DropColumn("dbo.Feedbacks", "Type");
            DropColumn("dbo.Feedbacks", "ProductName");
            CreateIndex("dbo.Feedbacks", "User_ID");
            CreateIndex("dbo.Feedbacks", "Pro_ID");
            AddForeignKey("dbo.Feedbacks", "User_ID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Feedbacks", "Pro_ID", "dbo.Products", "Pro_ID");
        }
    }
}
