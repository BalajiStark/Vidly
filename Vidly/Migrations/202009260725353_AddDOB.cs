﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDOB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateofBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateofBirth");
        }
    }
}
