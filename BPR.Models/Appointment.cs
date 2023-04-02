using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateCreated { get; set; }
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTimeExpected { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public Boolean AppointmentCancelled { get; set; }
        public int CustomerId { get; set; }
        public int AdministratorId { get; set; }
        public int AppointmentCategoryId { get; set; }
    }
}
