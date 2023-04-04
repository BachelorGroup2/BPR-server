using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPR.Models
{
   public class Administrator
    {
        [Key]
        public int AdministratorId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string AdministratorFirstName { get; set; }
        public string AdministratorSurname { get; set; }
        [Required]
        [EmailAddress]
        public string AdministratorEmail { get; set; }
        [StringLength(16, MinimumLength = 6)]
        public string AdministratorPhoneNumber { get; set; }
    }
}
