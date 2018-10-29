namespace NewStar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Students", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Students", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Students", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Students", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Status");
            DropColumn("dbo.Students", "UpdatedBy");
            DropColumn("dbo.Students", "UpdatedDate");
            DropColumn("dbo.Students", "CreatedBy");
            DropColumn("dbo.Students", "CreatedDate");
        }
    }
}
