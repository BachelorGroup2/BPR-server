using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class RoomBooking
    {
        [Key]
        public int RoomBookingId { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
    }
}
