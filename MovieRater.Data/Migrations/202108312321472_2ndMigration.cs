namespace MovieRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Movie", newName: "TVShow");
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        ParentalGuidance = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        MainCharacters = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.TVShow", "Seasons", c => c.Int(nullable: false));
            DropColumn("dbo.TVShow", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TVShow", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TVShow", "Seasons", c => c.Int());
            DropTable("dbo.Movie");
            RenameTable(name: "dbo.TVShow", newName: "Movie");
        }
    }
}
