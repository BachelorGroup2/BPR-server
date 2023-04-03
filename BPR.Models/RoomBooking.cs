using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class RoomBooking
    {
        public int RoomBookingId { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
    }
}
