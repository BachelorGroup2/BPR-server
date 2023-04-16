using System;
using System.Collections.Generic;

#nullable disable

namespace APIProject.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public int RoomCategoryId { get; set; }

        public virtual RoomCategory RoomCategory { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
