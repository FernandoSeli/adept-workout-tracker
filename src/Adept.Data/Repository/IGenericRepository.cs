using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> RemoveAsync(T test);
    }
}