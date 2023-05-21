using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class KamtjatkaInfoRepository : RepositoryBase<KamtjatkaInfo>, IKamtjatkaInfoRepository
    {
        public KamtjatkaInfoRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
