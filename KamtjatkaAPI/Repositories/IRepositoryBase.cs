using System.Collections.Generic;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task<T> Delete(int id);
    }
}

