using System;

namespace BPR.Models
{
    public class RoomCategory
    {
        [Key]
        public int RoomCategoryId { get; set; }
        [Required]
        public string RoomCategoryName { get; set; }
        public string RoomCategoryDescription { get; set; }
        [Required]
        public int RoomCategoryNumberOfRooms { get; set; }
        [Required]
        public string RoomCategoryUtilities { get; set; }
        [Required]
        public string RoomCategoryRentPrice { get; set; }
        [Required]
        public string RoomCategoryDeposit { get; set; }
        public int RoomCategoryPictureLink { get; set; }
    }
}
