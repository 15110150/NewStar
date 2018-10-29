namespace NewStar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertisingObjects",
                c => new
                    {
                        ContactID = c.Int(nullable: false),
                        MarketingCampaignID = c.Int(nullable: false),
                        TotalObject = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContactID, t.MarketingCampaignID })
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: true)
                .ForeignKey("dbo.MarketingCampaigns", t => t.MarketingCampaignID, cascadeDelete: true)
                .Index(t => t.ContactID)
                .Index(t => t.MarketingCampaignID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContactName = c.String(maxLength: 255),
                        Address1 = c.String(maxLength: 255),
                        MobilePhone = c.String(maxLength: 20),
                        WorkPhone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        Email = c.String(maxLength: 255),
                        Website = c.String(maxLength: 255),
                        Facebook = c.String(maxLength: 255),
                        Skype = c.String(maxLength: 255),
                        Comment = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MarketingCampaigns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(maxLength: 255),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CampaignType = c.String(),
                        Frequency = c.String(),
                        Content = c.String(),
                        Objective = c.String(),
                        ExpectedRevenue = c.Single(nullable: false),
                        ActualCost = c.Single(nullable: false),
                        ExpectedCost = c.Single(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberStudent = c.String(),
                        OpenDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CourseID = c.Int(nullable: false),
                        MarkID = c.Int(nullable: false),
                        Description = c.String(maxLength: 4000),
                        Room = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 4000),
                        CourseCategoryID = c.Int(nullable: false),
                        IsLongTerm = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CourseCategories", t => t.CourseCategoryID, cascadeDelete: true)
                .Index(t => t.CourseCategoryID);
            
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        ParentID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ClassOrganizations",
                c => new
                    {
                        ClassID = c.Int(nullable: false),
                        LecturerID = c.Int(nullable: false),
                        IsMainLecture = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassID, t.LecturerID })
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Lecturers", t => t.LecturerID, cascadeDelete: true)
                .Index(t => t.ClassID)
                .Index(t => t.LecturerID);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Birthdate = c.DateTime(nullable: false),
                        Diploma = c.String(maxLength: 255),
                        IdentityNo = c.String(maxLength: 255),
                        NSContactID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NSContacts", t => t.NSContactID, cascadeDelete: true)
                .Index(t => t.NSContactID);
            
            CreateTable(
                "dbo.NSContacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContactName = c.String(maxLength: 255),
                        Address1 = c.String(maxLength: 255),
                        Address2 = c.String(maxLength: 255),
                        Address3 = c.String(maxLength: 255),
                        MobilePhone = c.String(maxLength: 20),
                        WorkPhone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        Email = c.String(maxLength: 255),
                        Comment = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseMarketings",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        MarketingCampaignID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.MarketingCampaignID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.MarketingCampaigns", t => t.MarketingCampaignID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.MarketingCampaignID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DiscountCode = c.String(),
                        Description = c.String(maxLength: 4000),
                        DiscountValue = c.Single(nullable: false),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidUntil = c.DateTime(nullable: false),
                        CourseID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Content = c.String(),
                        Note = c.String(),
                        ClassID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        DiscountID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.DiscountID, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.ClassID)
                .Index(t => t.StudentID)
                .Index(t => t.DiscountID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Birthdate = c.DateTime(nullable: false),
                        IsPotentialStudent = c.Boolean(nullable: false),
                        ContactID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: true)
                .Index(t => t.ContactID);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ClassID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 4000),
                        MidMark = c.Single(nullable: false),
                        FinalMark = c.Single(nullable: false),
                        TotalMark = c.Single(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassID, t.StudentID })
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.ClassID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.NSUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 255),
                        Password = c.String(maxLength: 255),
                        FullName = c.String(nullable: false, maxLength: 255),
                        NSContactID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        Comment = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NSContacts", t => t.NSContactID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.NSContactID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 255),
                        Comment = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PotentialStudent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Birthdate = c.DateTime(nullable: false),
                        IsPotentialStudent = c.Boolean(nullable: false),
                        NSContactID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NSContacts", t => t.NSContactID, cascadeDelete: true)
                .Index(t => t.NSContactID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Unit = c.String(maxLength: 50),
                        Description = c.String(maxLength: 4000),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Time = c.DateTime(nullable: false),
                        CourseID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        ValueString = c.String(maxLength: 50),
                        ValueInt = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaskName = c.String(maxLength: 255),
                        Description = c.String(maxLength: 4000),
                        ContactID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: true)
                .Index(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Prices", "CourseID", "dbo.Course");
            DropForeignKey("dbo.PotentialStudent", "NSContactID", "dbo.NSContacts");
            DropForeignKey("dbo.NSUsers", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.NSUsers", "NSContactID", "dbo.NSContacts");
            DropForeignKey("dbo.Marks", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Marks", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.Invoices", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Invoices", "DiscountID", "dbo.Discounts");
            DropForeignKey("dbo.Invoices", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.Discounts", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseMarketings", "MarketingCampaignID", "dbo.MarketingCampaigns");
            DropForeignKey("dbo.CourseMarketings", "CourseID", "dbo.Course");
            DropForeignKey("dbo.ClassOrganizations", "LecturerID", "dbo.Lecturers");
            DropForeignKey("dbo.Lecturers", "NSContactID", "dbo.NSContacts");
            DropForeignKey("dbo.ClassOrganizations", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.Classes", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course", "CourseCategoryID", "dbo.CourseCategories");
            DropForeignKey("dbo.AdvertisingObjects", "MarketingCampaignID", "dbo.MarketingCampaigns");
            DropForeignKey("dbo.AdvertisingObjects", "ContactID", "dbo.Contacts");
            DropIndex("dbo.Tasks", new[] { "ContactID" });
            DropIndex("dbo.Prices", new[] { "CourseID" });
            DropIndex("dbo.PotentialStudent", new[] { "NSContactID" });
            DropIndex("dbo.NSUsers", new[] { "RoleID" });
            DropIndex("dbo.NSUsers", new[] { "NSContactID" });
            DropIndex("dbo.Marks", new[] { "StudentID" });
            DropIndex("dbo.Marks", new[] { "ClassID" });
            DropIndex("dbo.Students", new[] { "ContactID" });
            DropIndex("dbo.Invoices", new[] { "DiscountID" });
            DropIndex("dbo.Invoices", new[] { "StudentID" });
            DropIndex("dbo.Invoices", new[] { "ClassID" });
            DropIndex("dbo.Discounts", new[] { "CourseID" });
            DropIndex("dbo.CourseMarketings", new[] { "MarketingCampaignID" });
            DropIndex("dbo.CourseMarketings", new[] { "CourseID" });
            DropIndex("dbo.Lecturers", new[] { "NSContactID" });
            DropIndex("dbo.ClassOrganizations", new[] { "LecturerID" });
            DropIndex("dbo.ClassOrganizations", new[] { "ClassID" });
            DropIndex("dbo.Course", new[] { "CourseCategoryID" });
            DropIndex("dbo.Classes", new[] { "CourseID" });
            DropIndex("dbo.AdvertisingObjects", new[] { "MarketingCampaignID" });
            DropIndex("dbo.AdvertisingObjects", new[] { "ContactID" });
            DropTable("dbo.Tasks");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.Prices");
            DropTable("dbo.PotentialStudent");
            DropTable("dbo.Roles");
            DropTable("dbo.NSUsers");
            DropTable("dbo.Marks");
            DropTable("dbo.Students");
            DropTable("dbo.Invoices");
            DropTable("dbo.Errors");
            DropTable("dbo.Discounts");
            DropTable("dbo.CourseMarketings");
            DropTable("dbo.NSContacts");
            DropTable("dbo.Lecturers");
            DropTable("dbo.ClassOrganizations");
            DropTable("dbo.CourseCategories");
            DropTable("dbo.Course");
            DropTable("dbo.Classes");
            DropTable("dbo.MarketingCampaigns");
            DropTable("dbo.Contacts");
            DropTable("dbo.AdvertisingObjects");
        }
    }
}
