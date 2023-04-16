using System;
using System.Collections.Generic;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class FinanceCategory
    {
        public FinanceCategory()
        {
            Finances = new HashSet<Finance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Finance> Finances { get; set; }
    }
}
