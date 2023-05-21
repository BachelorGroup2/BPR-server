using KamtjatkaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomerWithRoomCategory();
    }
}
