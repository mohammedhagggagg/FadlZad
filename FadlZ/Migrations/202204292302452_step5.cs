namespace FadlZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Pro_ID = c.String(maxLength: 128),
                        User_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FeedID)
                .ForeignKey("dbo.Products", t => t.Pro_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_ID)
                .Index(t => t.Pro_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "User_ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Feedbacks", "Pro_ID", "dbo.Products");
            DropIndex("dbo.Feedbacks", new[] { "User_ID" });
            DropIndex("dbo.Feedbacks", new[] { "Pro_ID" });
            DropTable("dbo.Feedbacks");
        }
    }
}
