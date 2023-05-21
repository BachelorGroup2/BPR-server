#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int KamtjatkaInfoId { get; set; }

        public virtual KamtjatkaInfo KamtjatkaInfo { get; set; }
    }
}
