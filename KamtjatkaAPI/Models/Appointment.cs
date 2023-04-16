using System;
using System.Collections.Generic;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTimeExpected { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Cancelled { get; set; }
        public int CustomerId { get; set; }
        public int AdministratorId { get; set; }
        public int AppointmentCategoryId { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual AppointmentCategory AppointmentCategory { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
