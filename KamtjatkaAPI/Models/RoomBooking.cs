using System;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class RoomBooking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? StartRentDate { get; set; }
        public DateTime? EndRentDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}
