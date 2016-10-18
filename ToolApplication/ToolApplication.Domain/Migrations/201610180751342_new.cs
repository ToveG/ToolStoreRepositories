namespace ToolApplication.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        ailes = c.Int(nullable: false),
                        shelf = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToolType = c.Int(nullable: false),
                        BatteryTime = c.Decimal(precision: 18, scale: 2),
                        WireLength = c.Decimal(precision: 18, scale: 2),
                        Inventory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventories", t => t.Inventory_Id)
                .Index(t => t.Inventory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tools", "Inventory_Id", "dbo.Inventories");
            DropIndex("dbo.Tools", new[] { "Inventory_Id" });
            DropTable("dbo.Tools");
            DropTable("dbo.Inventories");
        }
    }
}
