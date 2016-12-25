using ExpenseLibrary;
using ExpenseModel;
using IExpenseBusiness;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExpenseBusiness
{
    public class ExpenseConsumerRepository : IExpenseConsumerRepository
    {
        private readonly ExpenseSystemContext db;
        public ExpenseConsumerRepository()
        {
            db = new ExpenseSystemContext();
        }
        public ExpenseConsumer AddExpenseConsumer(ExpenseConsumer expenseConsumer)
        {
            var result = db.tblExpenseConsumers.Add(expenseConsumer);
            db.SaveChanges();
            return result;
        }
        public IEnumerable<ExpenseConsumer> GetAllExpenseConsumers()
        {
            return db.tblExpenseConsumers.ToList();
        }
        public ExpenseConsumer GetExpenseConsumerByID(int id)
        {
            return db.tblExpenseConsumers.Where(s => s.Id == id).SingleOrDefault();
        }
        public void DeleteExpenseConsumer(ExpenseConsumer expenseConsumer)
        {
            db.tblExpenseConsumers.Remove(expenseConsumer);
            db.SaveChanges();
        }
        public void DeleteExpenseConsumer(int id)
        {
            ExpenseConsumer expenseConsumer = GetExpenseConsumerByID(id);
            db.tblExpenseConsumers.Remove(expenseConsumer);
            db.SaveChanges();
        }

        public void DeleteExpenseConsumerByExpenseId(int expenseId)
        {
            var existsRecord = db.tblExpenseConsumers.Any(ec => ec.ExpenseId == expenseId);
            if (existsRecord)
            {
                db.tblExpenseConsumers.RemoveRange(db.tblExpenseConsumers.Where(ec => ec.ExpenseId == expenseId));
                db.SaveChanges();
            }
        }
        public void UpdateExpenseConsumer(ExpenseConsumer expenseConsumer)
        {
            db.tblExpenseConsumers.Attach(expenseConsumer);
            db.Entry(expenseConsumer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public dynamic GetExpenseConsumerByExpenseID(int expenseID)
        {
            return db.tblExpenseConsumers.Where(s => s.ExpenseId == expenseID)
                .Join(db.tblConsumers, ec => ec.ConsumerId, c => c.Id, (ec, c) => new { ec.ExpenseId, c.Id, c.Name }).ToList();
        }
        ~ExpenseConsumerRepository()
        {
            db.Dispose();
        }
    }
}
