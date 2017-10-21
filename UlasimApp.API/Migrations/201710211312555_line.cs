namespace UlasimApp.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class line : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lines", "From", c => c.String());
            AddColumn("dbo.Lines", "To", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lines", "To");
            DropColumn("dbo.Lines", "From");
        }
    }
}
