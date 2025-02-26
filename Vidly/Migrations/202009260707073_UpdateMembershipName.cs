﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("update MemberShipTypes set Name = 'Pay as you go' where Id = 1");
            Sql("update MemberShipTypes set Name = 'Quarterly' where Id = 2");
            Sql("update MemberShipTypes set Name = 'Monthly' where Id = 3");
            Sql("update MemberShipTypes set Name = 'Annual' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
