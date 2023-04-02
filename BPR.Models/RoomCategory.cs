using System;

namespace BPR.Models
{
    public class RoomCategory
    {
        public int RoomCategoryId { get; set; }
        public string RoomCategoryName { get; set; }
        public string RoomCategoryDescription { get; set; }
        public int RoomCategoryNumberOfRooms { get; set; }
        public string RoomCategoryUtilities { get; set; }
        public string RoomCategoryRentPrice { get; set; }
        public string RoomCategoryDeposit { get; set; }
        public int RoomCategoryPictureLink { get; set; }
    }
}
