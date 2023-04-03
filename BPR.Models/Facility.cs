using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }
        [Required]
        public string FacilityName { get; set; }
        public string FacilityDescription { get; set; }
        public KamtjatkaInfo KamtjatkaInfoId { get; set; }
    }
}
