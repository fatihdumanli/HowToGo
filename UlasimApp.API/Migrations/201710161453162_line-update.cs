namespace UlasimApp.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lineupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lines", "Name", c => c.String());
            AddColumn("dbo.Lines", "IconUri", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lines", "IconUri");
            DropColumn("dbo.Lines", "Name");
        }
    }
}
