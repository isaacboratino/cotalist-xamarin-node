using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCotacao.Data.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item, Func<T, int, bool> where);
        Task<bool> DeleteAsync(T item, Func<T, int, bool> where);
        Task<T> GetAsync(Func<T, bool> where);
        Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false);
    }
}
