using KamtjatkaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public interface IFinanceRepository : IRepositoryBase<Finance>
    {
        Task<IEnumerable<Finance>> GetFinances();
        Task<IEnumerable<object>> GetInvoiceData();
    }
}