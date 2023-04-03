using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class Finance
    {
        public int FinanceId { get; set; }
        public string FinanceName { get; set; }
        public string FinanceAmountOfMoney { get; set; }
        public string FinanceDescription { get; set; }
        public int CustomerId { get; set; }
        public int FinanceCategoryId { get; set; }
    }
}
