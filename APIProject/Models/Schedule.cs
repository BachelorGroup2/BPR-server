using System;
using System.Collections.Generic;

#nullable disable

namespace APIProject.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int AdministratorId { get; set; }

        public virtual Administrator Administrator { get; set; }
    }
}
