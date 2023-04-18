using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public class AdministratorRepository : RepositoryBase<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
