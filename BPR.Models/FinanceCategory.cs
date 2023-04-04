using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class FinanceCategory
    {
        [Key]
        public int FinanceCategoryId { get; set; }
        [Required]
        [StringLength(20)]
        public string FinanceCategoryName { get; set; }
    }
}
