namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weeds", "PriceForOunce", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weeds", "PriceForOunce");
        }
    }
}
