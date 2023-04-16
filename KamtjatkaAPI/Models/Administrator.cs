using System;
using System.Collections.Generic;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            Appointments = new HashSet<Appointment>();
            KamtjatkaInfos = new HashSet<KamtjatkaInfo>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<KamtjatkaInfo> KamtjatkaInfos { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
