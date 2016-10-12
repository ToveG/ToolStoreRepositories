namespace ToolStore.domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
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
                        Weight = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        BatteryTime = c.Int(),
                        WireLength = c.Int(),
                        Inventory_Id = c.Int(),
                        ToolType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventories", t => t.Inventory_Id)
                .ForeignKey("dbo.ToolTypes", t => t.ToolType_Id)
                .Index(t => t.Inventory_Id)
                .Index(t => t.ToolType_Id);
            
            CreateTable(
                "dbo.ToolTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tools", "ToolType_Id", "dbo.ToolTypes");
            DropForeignKey("dbo.Tools", "Inventory_Id", "dbo.Inventories");
            DropIndex("dbo.Tools", new[] { "ToolType_Id" });
            DropIndex("dbo.Tools", new[] { "Inventory_Id" });
            DropTable("dbo.ToolTypes");
            DropTable("dbo.Tools");
            DropTable("dbo.Inventories");
        }
    }
}
