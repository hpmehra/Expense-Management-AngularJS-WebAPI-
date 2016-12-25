using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ExpenseLibrary;
using ExpenseModel;
using ExpenseModels.DomainModel;
using IExpenseBusiness;
namespace ExpenseBusiness
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseSystemContext db;
         public ExpenseRepository()
         {
             db = new ExpenseSystemContext();
         }
         public int AddExpense(Expense expense)
         {
             var result = db.tblExpenses.Add(expense);
             db.SaveChanges();
             return result.Id;
         }
         public IEnumerable<Expense> GetAllExpenses()
         {
             return db.tblExpenses.ToList();
         }
         public Expense GetExpenseByID(int id)
         {
             return db.tblExpenses.Where(s => s.Id == id).SingleOrDefault();
         }
         public void DeleteExpense(Expense expense)
         {
             db.tblExpenses.Remove(expense);
             db.SaveChanges();
         }
         public void DeleteExpense(int id)
         {
             Expense expense = GetExpenseByID(id);
             db.tblExpenses.Remove(expense);
             db.SaveChanges();
         }
         public int UpdateExpense(Expense expense)
         {
             db.tblExpenses.Attach(expense);
             db.Entry(expense).State = EntityState.Modified;
             db.SaveChanges();
            return expense.Id;
         }

         public dynamic GetExpenseBySiteID(int siteId)
         {
           return db.tblExpenses.Join(db.tblConsumers, exp => exp.PaidBy, cns => cns.Id, (exp, cns) => new { exp.Id, exp.ItemName, exp.Amount, exp.CreatedDate, exp.SiteId, cns.Name })
                .Where(exp => exp.SiteId == siteId).OrderByDescending(exp=>exp.Id).Take(10).ToList();
             //return db.tblExpenses.Where(s => s.SiteId == siteId).ToList();
         }

        public List<ExpenseReport> GetExpenseReportDetail()
        {
            var result = db.Database.SqlQuery<ExpenseReport>("dbo.GetExpenseReportData").ToList();
            return result;
        }

        ~ExpenseRepository()
        {
            db.Dispose();
        }
    }
}
