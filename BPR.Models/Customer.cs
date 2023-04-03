using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerSurname { get; set; }
        public string Nationality { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreetName { get; set; }
        public string CustomerStreetNumber { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public Boolean CustomerRegistered { get; set; }
        public string CustomerPassportNumber { get; set; }
        public string CustomerIdNumber { get; set; }
        public DateTime CustomerAccountCreation { get; set; }
    }
}
