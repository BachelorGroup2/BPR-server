using System.Collections.Generic;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class AppointmentCategory
    {
        public AppointmentCategory()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
