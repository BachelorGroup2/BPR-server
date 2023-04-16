using System;
using System.Collections.Generic;

#nullable disable

namespace APIProject.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
            Finances = new HashSet<Finance>();
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Registered { get; set; }
        public string PassportNumber { get; set; }
        public string IdNumber { get; set; }
        public DateTime AccountCreation { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Finance> Finances { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
