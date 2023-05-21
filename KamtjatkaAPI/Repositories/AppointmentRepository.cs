using KamtjatkaAPI.Models;

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
