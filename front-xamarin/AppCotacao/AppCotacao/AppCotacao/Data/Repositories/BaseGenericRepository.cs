using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCotacao.Data.Repositories
{
    public abstract class BaseGenericDataStore<T> : IGenericRepository<T> where T : class
    {
        public List<T> items { get;  set; }
        
        public async Task<bool> AddAsync(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(T item, Func<T, int, bool> where)
        {
            var _item = items.Where(where).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(T item, Func<T, int, bool> where)
        {
            //(T arg) => arg.Id == item.Id
            var _item = items.Where(where).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(Func<T, bool> where)
        {
            return await Task.FromResult(items.FirstOrDefault(where));
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}