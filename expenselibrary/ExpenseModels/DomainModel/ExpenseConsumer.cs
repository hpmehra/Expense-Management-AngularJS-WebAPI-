using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseModel
{
    public class ExpenseConsumer
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int ConsumerId { get; set; }
        
        [ForeignKey("ConsumerId")]
        public Consumer tblConsumers { get; set; }
        
        [ForeignKey("ExpenseId")]
        public Expense tblsExpenses { get; set; }
    }
}
