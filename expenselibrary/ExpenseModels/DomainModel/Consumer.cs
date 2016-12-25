using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseModel
{
    public class Consumer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SiteId { get; set; }
        
        [ForeignKey("SiteId")]
        public Site tblSites { get; set; }

        //public virtual ICollection<Expense> tblExpenses { get; set; }
        //public virtual ICollection<ExpenseConsumer> tblExpenseConsumers { get; set; }
    }
}
