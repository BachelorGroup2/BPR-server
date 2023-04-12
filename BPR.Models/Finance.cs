using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class Finance
    {
        [Key]
        public int FinanceId { get; set; }
        [Required]
        [StringLength(20)]
        public string FinanceName { get; set; }
        [Required]
        public string FinanceAmountOfMoney { get; set; }
        public string FinanceDescription { get; set; }
        public int CustomerId { get; set; }
        public int FinanceCategoryId { get; set; }
    }
}
