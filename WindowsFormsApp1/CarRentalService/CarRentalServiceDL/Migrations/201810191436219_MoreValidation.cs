namespace CarRentalServiceDL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Returned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Returned");
        }
    }
}
