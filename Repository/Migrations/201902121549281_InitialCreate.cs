namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Weeds",
                c => new
                    {
                        WeedId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        WeedType = c.Int(nullable: false),
                        WeedKind = c.Int(nullable: false),
                        Description = c.String(),
                        LongDescription = c.String(),
                        
                        Pic = c.Binary(),
                        Pic2 = c.Binary(),
                        Pic3 = c.Binary(),
                    })
                .PrimaryKey(t => t.WeedId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weeds", "UserId", "dbo.Users");
            DropIndex("dbo.Weeds", new[] { "UserId" });
            DropTable("dbo.Weeds");
            DropTable("dbo.Users");
        }
    }
}
