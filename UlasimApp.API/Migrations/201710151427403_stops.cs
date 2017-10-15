namespace UlasimApp.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stops : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stops");
        }
    }
}
