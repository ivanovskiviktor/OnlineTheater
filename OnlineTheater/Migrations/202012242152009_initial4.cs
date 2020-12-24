namespace OnlineTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayReservations",
                c => new
                    {
                        reservationID = c.Int(nullable: false, identity: true),
                        selectedPlay_PlayId = c.Int(),
                        theatre_TheatreId = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.reservationID)
                .ForeignKey("dbo.Plays", t => t.selectedPlay_PlayId)
                .ForeignKey("dbo.Theatres", t => t.theatre_TheatreId)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.selectedPlay_PlayId)
                .Index(t => t.theatre_TheatreId)
                .Index(t => t.user_Id);
            
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayReservations", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PlayReservations", "theatre_TheatreId", "dbo.Theatres");
            DropForeignKey("dbo.PlayReservations", "selectedPlay_PlayId", "dbo.Plays");
            DropIndex("dbo.PlayReservations", new[] { "user_Id" });
            DropIndex("dbo.PlayReservations", new[] { "theatre_TheatreId" });
            DropIndex("dbo.PlayReservations", new[] { "selectedPlay_PlayId" });
            DropColumn("dbo.AspNetUsers", "Address");
            DropTable("dbo.PlayReservations");
        }
    }
}
