using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class AppointmentCategory
    {
        [Key]
        public int AppointmentCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string AppointmentCategoryName { get; set; }
        [Required]
        public int AppointmentCategoryDuration { get; set; }
    }
}
