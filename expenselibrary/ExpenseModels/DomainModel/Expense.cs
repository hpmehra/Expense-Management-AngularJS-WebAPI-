using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseModel
{
    public class Expense
    {
        public int Id { get; set; }        
        public int SiteId { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public int PaidBy { get; set; }
        public bool IsAudit { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? AuditDate { get; set; }
       
        [ForeignKey("SiteId")]
        public Site tblSites { get; set; }
        
        [ForeignKey("PaidBy")]
        public Consumer tblConsumers { get; set; }

 //       public virtual ICollection<ExpenseConsumer> tblExpenseConsumers { get; set; }
    }
}
