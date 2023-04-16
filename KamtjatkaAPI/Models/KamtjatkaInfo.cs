using System;
using System.Collections.Generic;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class KamtjatkaInfo
    {
        public KamtjatkaInfo()
        {
            Facilities = new HashSet<Facility>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public int AdministratorId { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}
