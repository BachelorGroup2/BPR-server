using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{

        public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
        {
            public CustomerRepository(vujeeaxiContext repositoryContext)
              : base(repositoryContext)
            {

            }
        }
}

