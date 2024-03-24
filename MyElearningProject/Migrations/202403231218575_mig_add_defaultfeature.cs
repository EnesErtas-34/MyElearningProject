namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_defaultfeature : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefaultFeatures",
                c => new
                    {
                        DefaultFeatureID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Title2 = c.String(),
                        Description = c.String(),
                        Description2 = c.String(),
                        ImageURL = c.String(),
                        ImageURL2 = c.String(),
                    })
                .PrimaryKey(t => t.DefaultFeatureID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DefaultFeatures");
        }
    }
}
