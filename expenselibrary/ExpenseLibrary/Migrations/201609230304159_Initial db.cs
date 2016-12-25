namespace ExpenseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: false)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.ExpenseConsumers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseId = c.Int(nullable: false),
                        ConsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumers", t => t.ConsumerId, cascadeDelete: false)
                .ForeignKey("dbo.Expenses", t => t.ExpenseId, cascadeDelete: false)
                .Index(t => t.ExpenseId)
                .Index(t => t.ConsumerId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteId = c.Int(nullable: false),
                        ItemName = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidBy = c.Int(nullable: false),
                        IsAudit = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        AuditDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumers", t => t.PaidBy, cascadeDelete: false)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: false)
                .Index(t => t.SiteId)
                .Index(t => t.PaidBy);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.Consumers", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.ExpenseConsumers", "ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "PaidBy", "dbo.Consumers");
            DropForeignKey("dbo.ExpenseConsumers", "ConsumerId", "dbo.Consumers");
            DropIndex("dbo.Expenses", new[] { "PaidBy" });
            DropIndex("dbo.Expenses", new[] { "SiteId" });
            DropIndex("dbo.ExpenseConsumers", new[] { "ConsumerId" });
            DropIndex("dbo.ExpenseConsumers", new[] { "ExpenseId" });
            DropIndex("dbo.Consumers", new[] { "SiteId" });
            DropTable("dbo.Sites");
            DropTable("dbo.Expenses");
            DropTable("dbo.ExpenseConsumers");
            DropTable("dbo.Consumers");
        }
    }
}
