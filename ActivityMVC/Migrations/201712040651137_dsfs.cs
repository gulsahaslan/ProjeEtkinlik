namespace ActivityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(),
                        Location = c.String(nullable: false),
                        Price = c.String(),
                        MaxPerson = c.Int(nullable: false),
                        Aciklama = c.String(unicode: false, storeType: "text"),
                        PictureName = c.String(),
                        Category_CategoryID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        StartLocation = c.String(nullable: false),
                        FinishLocation = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Price = c.String(),
                        Activity_ActivityID = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID)
                .Index(t => t.Activity_ActivityID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 10),
                        Job = c.String(),
                        Gender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.MemberActivities",
                c => new
                    {
                        Member_MemberID = c.Int(nullable: false),
                        Activity_ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberID, t.Activity_ActivityID })
                .ForeignKey("dbo.Members", t => t.Member_MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID, cascadeDelete: true)
                .Index(t => t.Member_MemberID)
                .Index(t => t.Activity_ActivityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Services", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.MemberActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.MemberActivities", "Member_MemberID", "dbo.Members");
            DropForeignKey("dbo.Activities", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.MemberActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.MemberActivities", new[] { "Member_MemberID" });
            DropIndex("dbo.Services", new[] { "Activity_ActivityID" });
            DropIndex("dbo.Activities", new[] { "User_UserID" });
            DropIndex("dbo.Activities", new[] { "Category_CategoryID" });
            DropTable("dbo.MemberActivities");
            DropTable("dbo.Users");
            DropTable("dbo.Services");
            DropTable("dbo.Members");
            DropTable("dbo.Categories");
            DropTable("dbo.Activities");
        }
    }
}
