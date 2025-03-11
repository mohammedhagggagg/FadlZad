namespace FadlZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedbacks", "Message", c => c.String());
        }
    }
}
