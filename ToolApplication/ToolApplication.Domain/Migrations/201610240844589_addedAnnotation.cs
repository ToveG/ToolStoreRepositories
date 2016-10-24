namespace ToolApplication.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tools", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tools", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tools", "Description", c => c.String());
            AlterColumn("dbo.Tools", "Name", c => c.String());
        }
    }
}
