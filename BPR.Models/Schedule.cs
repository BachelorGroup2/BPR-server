using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    class Schedule
    {
        public int ScheduleId { get; set; }
        public  DateTime ScheduleFrom { get; set; }
        public  DateTime ScheduleTo { get; set; }
        public int AdministratorId { get; set; }

    }
}
