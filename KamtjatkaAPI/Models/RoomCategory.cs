using System;
using System.Collections.Generic;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class RoomCategory
    {
        public RoomCategory()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public string RentPrice { get; set; }
        public string Deposit { get; set; }
        public string PictureLink { get; set; }
        public string LongDescription { get; set; }
        public string Consuption { get; set; }
        public string MoveInPrice { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
