using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    class KamtjatkaInfo
    {
        public int KamtjatkaInfoId { get; set; }
        public string KamtjatkaInfoStreetName { get; set; }
        public string KamtjatkaInfoStreetNumber { get; set; }
        public string KamtjatkaInfoPostalCode { get; set; }
        public string KamtjatkaInfoCity { get; set; }
        public string KamtjatkaInfoCountry { get; set; }
        public string KamtjatkaInforPhoneNumber { get; set; }
        public int AdministratorId  { get; set; }
    }
}
