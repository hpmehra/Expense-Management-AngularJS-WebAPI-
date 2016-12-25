namespace ExpenseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSiteModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sites", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sites", "Password");
        }
    }
}
