using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class KamtjatkaInfo
    {
        [Key]
        public int KamtjatkaInfoId { get; set; }
        [Required]
        [StringLength(20)]
        public string KamtjatkaInfoStreetName { get; set; }
        [Required]
        [StringLength(10)]
        public string KamtjatkaInfoStreetNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string KamtjatkaInfoPostalCode { get; set; }
        [Required]
        [StringLength(30)]
        public string KamtjatkaInfoCity { get; set; }
        [Required]
        [StringLength(50)]
        public string KamtjatkaInfoCountry { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 6)]
        public string KamtjatkaInforPhoneNumber { get; set; }
        public Administrator AdministratorId  { get; set; }
    }
}
