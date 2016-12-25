using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseModel
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Consumer> tblConsumers { get; set; }
        public virtual ICollection<Expense> tblExpenses { get; set; }
    }
}
