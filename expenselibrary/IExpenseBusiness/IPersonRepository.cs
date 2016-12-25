using System.Collections.Generic;
using ExpenseModel;
using ExpenseModel.ModelDto;

namespace IExpenseBusiness
{
    public interface IPersonRepository
    {
        Consumer AddPerson(Consumer consumer);
        IEnumerable<Consumer> GetAllPersons();
        IEnumerable<ConsumerDto> GetAllPersonsDetail(int expenseID);
        Consumer GetPersonByID(int id);
        void DeletePerson(Consumer Consumer);
        void DeletePerson(int id);
        void UpdatePerson(Consumer Consumer);
        IEnumerable<Consumer> GetPersonBySiteID(int siteId);
    }

}
