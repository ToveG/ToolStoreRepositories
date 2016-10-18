namespace ToolStore.domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tools", "Name", c => c.String());
            AlterColumn("dbo.Tools", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tools", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Tools", "Name", c => c.String(nullable: false));
        }
    }
}
