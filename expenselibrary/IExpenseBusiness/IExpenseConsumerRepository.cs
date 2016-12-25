using ExpenseModel;
using System.Collections.Generic;

namespace IExpenseBusiness
{
    public interface IExpenseConsumerRepository
    {
        ExpenseConsumer AddExpenseConsumer(ExpenseConsumer expenseConsumer);
        IEnumerable<ExpenseConsumer> GetAllExpenseConsumers();
        ExpenseConsumer GetExpenseConsumerByID(int id);
        void DeleteExpenseConsumer(ExpenseConsumer expenseConsumer);
        void DeleteExpenseConsumer(int id);
        void DeleteExpenseConsumerByExpenseId(int expenseId);
        void UpdateExpenseConsumer(ExpenseConsumer expenseConsumer);
        dynamic GetExpenseConsumerByExpenseID(int expenseID);
    }
}
