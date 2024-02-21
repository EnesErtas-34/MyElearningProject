namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_aboutfeature : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutFeatures",
                c => new
                    {
                        AboutFeatureID = c.Int(nullable: false, identity: true),
                        icon = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AboutFeatureID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutFeatures");
        }
    }
}
