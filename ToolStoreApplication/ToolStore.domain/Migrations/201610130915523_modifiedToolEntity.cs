namespace ToolStore.domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedToolEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "Category", c => c.Int(nullable: false));
            AlterColumn("dbo.Tools", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tools", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Tools", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tools", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tools", "BatteryTime", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Tools", "WireLength", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tools", "WireLength", c => c.Int());
            AlterColumn("dbo.Tools", "BatteryTime", c => c.Int());
            AlterColumn("dbo.Tools", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Tools", "Weight", c => c.Int(nullable: false));
            AlterColumn("dbo.Tools", "Description", c => c.String());
            AlterColumn("dbo.Tools", "Name", c => c.String());
            AlterColumn("dbo.Inventories", "Category", c => c.String());
        }
    }
}
