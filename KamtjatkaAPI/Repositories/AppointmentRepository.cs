using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
