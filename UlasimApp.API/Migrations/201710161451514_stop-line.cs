namespace UlasimApp.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stopline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lines", "ToId", c => c.Int(nullable: false));
            AddColumn("dbo.Stops", "LineId", c => c.Int(nullable: false));
            DropColumn("dbo.Lines", "From");
            DropColumn("dbo.Lines", "To");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lines", "To", c => c.String());
            AddColumn("dbo.Lines", "From", c => c.String());
            DropColumn("dbo.Stops", "LineId");
            DropColumn("dbo.Lines", "ToId");
        }
    }
}
