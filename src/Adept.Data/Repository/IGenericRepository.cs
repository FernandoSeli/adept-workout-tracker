using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> RemoveAsync(T entity);
        Task<int> AddRangeAsync(List<T> entities);
        Task<int> AddAsync(T entity);
        Task<int> RemoveRangeAsync(List<T> entities);
        Task<int> AddOrUpdateAsync(T entity);
        Task<int> AddOrUpdateRangeAsync(List<T> entities);

    }
}