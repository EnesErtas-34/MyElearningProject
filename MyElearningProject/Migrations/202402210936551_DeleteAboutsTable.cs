namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAboutsTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Abouts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Material = c.String(),
                    })
                .PrimaryKey(t => t.AboutID);
            
        }
    }
}
