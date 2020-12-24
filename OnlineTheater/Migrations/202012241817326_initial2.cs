    namespace OnlineTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(),
                        DirectorLastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.Plays",
                c => new
                    {
                        PlayId = c.Int(nullable: false, identity: true),
                        PlayName = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Publisher = c.String(),
                        Language = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayId);
            
            CreateTable(
                "dbo.Theatres",
                c => new
                    {
                        TheatreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TheatreId);
            
            CreateTable(
                "dbo.TheatrePlays",
                c => new
                    {
                        Theatre_TheatreId = c.Int(nullable: false),
                        Play_PlayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Theatre_TheatreId, t.Play_PlayId })
                .ForeignKey("dbo.Theatres", t => t.Theatre_TheatreId, cascadeDelete: true)
                .ForeignKey("dbo.Plays", t => t.Play_PlayId, cascadeDelete: true)
                .Index(t => t.Theatre_TheatreId)
                .Index(t => t.Play_PlayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TheatrePlays", "Play_PlayId", "dbo.Plays");
            DropForeignKey("dbo.TheatrePlays", "Theatre_TheatreId", "dbo.Theatres");
            DropIndex("dbo.TheatrePlays", new[] { "Play_PlayId" });
            DropIndex("dbo.TheatrePlays", new[] { "Theatre_TheatreId" });
            DropTable("dbo.TheatrePlays");
            DropTable("dbo.Theatres");
            DropTable("dbo.Plays");
            DropTable("dbo.Directors");
        }
    }
}
