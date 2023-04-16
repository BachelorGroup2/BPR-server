using System;
using System.Collections.Generic;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class Finance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AmountOfMoney { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int FinanceCategoryId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual FinanceCategory FinanceCategory { get; set; }
    }
}
