using ExpenseModel;
using ExpenseModels.DomainModel;
using System.Collections.Generic;

namespace IExpenseBusiness
{
    public interface IExpenseRepository
    {
        int AddExpense(Expense expense);
        IEnumerable<Expense> GetAllExpenses();
        Expense GetExpenseByID(int id);
        void DeleteExpense(Expense expense);
        void DeleteExpense(int id);
        int UpdateExpense(Expense expense);
        dynamic GetExpenseBySiteID(int siteId);
        List<ExpenseReport> GetExpenseReportDetail();
    }
}
