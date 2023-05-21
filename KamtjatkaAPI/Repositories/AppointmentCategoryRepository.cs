using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class AppointmentCategoryRepository : RepositoryBase<AppointmentCategory>, IAppointmentCategoryRepository
    {
        public AppointmentCategoryRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
