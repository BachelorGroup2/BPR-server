using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
