namespace FadlZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step41 : DbMigration
    {

        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            DropColumn("dbo.AspNetUsers", "City");
        }
    }
}
