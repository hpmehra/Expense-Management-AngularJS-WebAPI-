using ExpenseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseModel.ModelDto
{
   public class ConsumerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SiteId { get; set; }
        public int? ExpenseConsumerID { get; set; }
        public bool isChecked { get; set; }
    }
}
