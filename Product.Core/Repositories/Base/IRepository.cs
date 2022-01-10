using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Core.Repositories.Base
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteWithRangeAsync(IEnumerable<T> id);
    }
}
