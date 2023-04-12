using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public  DateTime ScheduleFrom { get; set; }
        [Required]
        public  DateTime ScheduleTo { get; set; }
        public int AdministratorId { get; set; }

    }
}
