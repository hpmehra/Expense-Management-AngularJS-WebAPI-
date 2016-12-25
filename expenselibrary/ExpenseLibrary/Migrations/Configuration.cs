namespace ExpenseLibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpenseLibrary.ExpenseSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpenseLibrary.ExpenseSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Consumer { FullName = "Andrew Peters" },
            //      new Consumer { FullName = "Brice Lambson" },
            //      new Consumer { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
