﻿namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_address : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressOfice = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}
