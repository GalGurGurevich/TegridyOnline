namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeuinit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weeds", "WeedStrength", c => c.Int(nullable: false));
            AddColumn("dbo.Weeds", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Weeds", "PriceForOunce", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weeds", "PriceForOunce", c => c.Byte(nullable: false));
            DropColumn("dbo.Weeds", "Quantity");
            DropColumn("dbo.Weeds", "WeedStrength");
        }
    }
}
