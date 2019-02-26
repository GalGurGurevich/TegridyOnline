namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weeds", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Weeds", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weeds", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Weeds", "Title");
        }
    }
}
