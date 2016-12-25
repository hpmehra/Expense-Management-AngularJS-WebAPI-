namespace ExpenseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expense : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Expenses", "AuditDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "AuditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Expenses", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
