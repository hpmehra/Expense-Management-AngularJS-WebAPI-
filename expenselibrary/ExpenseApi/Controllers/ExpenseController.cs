using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ExpenseBusiness;
using ExpenseModel;
using Newtonsoft.Json.Linq;
using ExpenseModel.ModelDto;
using ExpenseModels.DomainModel;

namespace ExpenseApi.Controllers
{
    public class ExpenseController : ApiController
    {
        //
        // GET: /Site/
        private PersonRepository personRepo;
        private readonly ExpenseRepository expRepo;
        private readonly SiteRepository siteRepo;
        private readonly ExpenseConsumerRepository expConsumerRepo;
        public ExpenseController()
        {
            personRepo = new PersonRepository();
            expRepo = new ExpenseRepository();
            siteRepo = new SiteRepository();
            expConsumerRepo = new ExpenseConsumerRepository();
        }

        [HttpGet]
        public IEnumerable<Consumer> GetConsumerAll()
        {
            try
            {
                return personRepo.GetAllPersons();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }


        [NonAction]
        private IEnumerable<ConsumerDto> GetConsumerDetailAll(int expenseID)
        {
            try
            {
                return personRepo.GetAllPersonsDetail(expenseID);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        [HttpGet]
        public IEnumerable<ConsumerDto> GetConsumerDetailAll()
        {
            try {
                return GetConsumerDetailAll(0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public bool saveExpense(JObject jobject)
        {
            try
            {
                dynamic jsonData = jobject;
                JObject jsonExpense = jsonData.expense;
                JArray expenseConsumers = jsonData.expenseConsumers;
                var varExpense = jsonExpense.ToObject<Expense>();
                int expenseId;
                if (varExpense.Id == 0)
                {
                    varExpense.SiteId = 1;
                    varExpense.CreatedDate = System.DateTime.Now;
                    expenseId = expRepo.AddExpense(varExpense);
                }
                else
                {
                    varExpense.ModifiedDate = System.DateTime.Now;
                    expenseId = expRepo.UpdateExpense(varExpense);
                }
                expConsumerRepo.DeleteExpenseConsumerByExpenseId(expenseId);
                foreach (var jsonExpConsumer in expenseConsumers)
                {
                    var jsonConsumerDTO = jsonExpConsumer.ToObject<ConsumerDto>();
                    if (jsonConsumerDTO.isChecked)
                    {
                        var expConsumer = jsonExpConsumer.ToObject<ExpenseConsumer>();
                        expConsumer.ExpenseId = expenseId;
                        expConsumer.ConsumerId = jsonConsumerDTO.Id;
                        saveExpenseConsumer(expConsumer);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public int saveSite(Site site)
        {
            try
            {
                var result = siteRepo.AddSite(site);
                if (result != null)
                    return result.Id;
                return 0;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [NonAction]
        private void saveExpenseConsumer(ExpenseConsumer expenseConsumers)
        {
            expConsumerRepo.AddExpenseConsumer(expenseConsumers);
        }

        [HttpPost]
        public dynamic getExpenseDetailBySiteId(int siteId)
        {
            try
            {
                return expRepo.GetExpenseBySiteID(siteId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public dynamic getExpenseDetailById(int id)
        {
            try
            {
                var expense = expRepo.GetExpenseByID(id);
                var expenseConsumer = GetConsumerDetailAll(id);
                return new { expense, expenseConsumer };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public bool deleteExpenseDetailByExpenseId(int expenseId)
        {
            try
            {
                expConsumerRepo.DeleteExpenseConsumerByExpenseId(expenseId);
                expRepo.DeleteExpense(expenseId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public int checkLoginDetail(Site site)
        {
            try
            {
                return siteRepo.checkLoginDetail(site);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [HttpPost]
        public Consumer saveConsumer(Consumer consumer)
        {
            try
            {
                return personRepo.AddPerson(consumer);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public IEnumerable<Consumer> getConsumerBySiteId(int siteId)
        {
            try
            {
                return personRepo.GetPersonBySiteID(siteId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<ExpenseReport> getExpenseReportDetail()
        {
            try
            {
                return expRepo.GetExpenseReportDetail();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
