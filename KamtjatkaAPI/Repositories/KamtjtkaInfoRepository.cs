using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
