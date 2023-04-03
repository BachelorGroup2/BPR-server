using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class RoomBooking
    {
        [Key]
        public int RoomBookingId { get; set; }
        public Room RoomId { get; set; }
        public Customer CustomerId { get; set; }
    }
}
