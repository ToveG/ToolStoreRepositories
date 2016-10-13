namespace ToolStore.domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedToolTypeEnum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tools", "ToolType_Id", "dbo.ToolTypes");
            DropIndex("dbo.Tools", new[] { "ToolType_Id" });
            AddColumn("dbo.Tools", "ToolType", c => c.Int(nullable: false));
            DropColumn("dbo.Tools", "ToolType_Id");
            DropTable("dbo.ToolTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ToolTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tools", "ToolType_Id", c => c.Int());
            DropColumn("dbo.Tools", "ToolType");
            CreateIndex("dbo.Tools", "ToolType_Id");
            AddForeignKey("dbo.Tools", "ToolType_Id", "dbo.ToolTypes", "Id");
        }
    }
}
