using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
