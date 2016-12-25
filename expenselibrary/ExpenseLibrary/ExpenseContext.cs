using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseModel;

namespace ExpenseLibrary
{
    public class ExpenseSystemContext : DbContext
    {
        public ExpenseSystemContext()
            : base("ExpenseSystemContext")
        {
        }

        public DbSet<Site> tblSites { get; set; }
        public DbSet<Consumer> tblConsumers { get; set; }
        public DbSet<Expense> tblExpenses { get; set; }
        public DbSet<ExpenseConsumer> tblExpenseConsumers { get; set; }

    }
}
