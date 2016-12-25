using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ExpenseLibrary;
using ExpenseModel;
using ExpenseModel.ModelDto;

namespace ExpenseBusiness
{
    public class PersonRepository
    {
        private readonly ExpenseSystemContext db;
        public PersonRepository()
        {
            db = new ExpenseSystemContext();
        }
        public Consumer AddPerson(Consumer consumer)
        {
            var result = db.tblConsumers.Add(consumer);
            db.SaveChanges();
            return result;
        }
        public IEnumerable<Consumer> GetAllPersons()
        {
            return db.tblConsumers.ToList();
        }
        public IEnumerable<ConsumerDto> GetAllPersonsDetail(int expenseID)
        {
            return (from cons in db.tblConsumers.ToList()
                    join consExp in db.tblExpenseConsumers.Where(expc => expc.ExpenseId == expenseID)
                   on cons.Id equals consExp.ConsumerId into consInfo
                    from consExps in consInfo.DefaultIfEmpty()
                    select new ConsumerDto
                    {
                        Id = cons.Id,
                        isChecked = (consExps == null || consExps.Id == 0) ? false : true,
                        Name = cons.Name,
                        SiteId = cons.SiteId,
                        ExpenseConsumerID = (consExps == null) ? 0 : consExps.Id
                    }).ToList();
        }
        public Consumer GetPersonByID(int id)
        {
            return db.tblConsumers.Where(s => s.Id == id).SingleOrDefault();
        }
        public void DeletePerson(Consumer Consumer)
        {
            db.tblConsumers.Remove(Consumer);
            db.SaveChanges();
        }
        public void DeletePerson(int id)
        {
            Consumer Consumer = GetPersonByID(id);
            db.tblConsumers.Remove(Consumer);
            db.SaveChanges();
        }
        public void UpdatePerson(Consumer Consumer)
        {
            db.tblConsumers.Attach(Consumer);
            db.Entry(Consumer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Consumer> GetPersonBySiteID(int siteId)
        {
            return db.tblConsumers.Where(s => s.SiteId == siteId).ToList();
        }

        ~PersonRepository()
        {
            db.Dispose();
        }
    }
}
