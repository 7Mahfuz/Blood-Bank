namespace Blood_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodBank2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "GotBlood", c => c.String());
            DropColumn("dbo.Requests", "GotOrNot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "GotOrNot", c => c.Int(nullable: false));
            DropColumn("dbo.Requests", "GotBlood");
        }
    }
}
