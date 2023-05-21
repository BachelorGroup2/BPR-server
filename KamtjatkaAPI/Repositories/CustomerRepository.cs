using KamtjatkaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly vujeeaxiContext appDbContext;
        public CustomerRepository(vujeeaxiContext appDbContext)
              : base(appDbContext)
            {
            this.appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Customer>> GetCustomerWithRoomCategory()
        {
            return await appDbContext.Customers.Include(f => f.RoomBookings).ThenInclude(rb => rb.Room.RoomCategory)

            .Select(f => new Customer
            {
                Id = f.Id,
                FirstName = f.FirstName,
                Surname = f.Surname,
                Email = f.Email,
                RoomBookings = f.RoomBookings,
            })
            .ToListAsync();
        }
    }
}

