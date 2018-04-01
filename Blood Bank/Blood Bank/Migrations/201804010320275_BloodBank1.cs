namespace Blood_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodBank1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonateLists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Reciever = c.String(),
                        Disease = c.String(),
                        Hospital = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Blood = c.String(),
                        Description = c.String(),
                        GotOrNot = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        BloodNeed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserName = c.String(),
                        Email = c.String(),
                        Blood = c.String(),
                        LastDonated = c.String(),
                        PreferedArea = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        RelativePhoneNumber = c.String(),
                        Relative = c.String(),
                        Show = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
            DropTable("dbo.DonateLists");
        }
    }
}
