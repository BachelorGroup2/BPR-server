using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string CustomerFirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string CustomerSurname { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 6)]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Required]
        [StringLength(20)]
        public string CustomerStreetName { get; set; }
        public string CustomerStreetNumber { get; set; }
        [Required]
        [StringLength(14)]
        public string CustomerPostalCode { get; set; }
        [Required]
        [StringLength(20)]
        public string CustomerCity { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerCountry { get; set; }
        public Boolean CustomerRegistered { get; set; }
        public string CustomerPassportNumber { get; set; }
        [Required]
        public string CustomerIdNumber { get; set; }
        public DateTime CustomerAccountCreation { get; set; }
    }
}
