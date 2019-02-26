namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedmodelstomatchspec : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weeds", "PublishDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Weeds", "PublishTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weeds", "PublishTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Weeds", "PublishDate");
        }
    }
}
