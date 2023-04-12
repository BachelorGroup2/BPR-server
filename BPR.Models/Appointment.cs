using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateCreated { get; set; }
        [Required]
        public DateTime AppointmentStartTime { get; set; } 
        [Required]
        public DateTime AppointmentEndTimeExpected { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public Boolean AppointmentCancelled { get; set; }
        public int CustomerId { get; set; }
        public int AdministratorId { get; set; }
        public int AppointmentCategoryId { get; set; }
    }
}
