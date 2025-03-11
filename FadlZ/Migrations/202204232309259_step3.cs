namespace FadlZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Cat_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Cat_Des", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Pro_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Pro_Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Pro_Type", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Pro_Image", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "Pro_Image", c => c.String());
            AlterColumn("dbo.Products", "Pro_Type", c => c.String());
            AlterColumn("dbo.Products", "Pro_Description", c => c.String());
            AlterColumn("dbo.Products", "Pro_Name", c => c.String());
            AlterColumn("dbo.Categories", "Cat_Des", c => c.String());
            AlterColumn("dbo.Categories", "Cat_Name", c => c.String());
        }
    }
}
