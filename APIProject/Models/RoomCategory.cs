using System;
using System.Collections.Generic;

#nullable disable

namespace APIProject.Models
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
        public string Utilities { get; set; }
        public string RentPrice { get; set; }
        public string Deposit { get; set; }
        public string PictureLink { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
