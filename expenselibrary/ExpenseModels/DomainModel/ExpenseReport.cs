using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseModels.DomainModel
{
  public  class ExpenseReport
    {
        public decimal? AmountPerHead { get; set; }
        public string Consumers { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? Balance { get; set; }
    }
}
