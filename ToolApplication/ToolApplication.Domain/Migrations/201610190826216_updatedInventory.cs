namespace ToolApplication.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedInventory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "Ailes", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "Ailes", c => c.Int(nullable: false));
        }
    }
}
