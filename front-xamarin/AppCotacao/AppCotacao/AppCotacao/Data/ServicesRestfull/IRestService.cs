using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCotacao.Data.ServicesRestfull
{
    public interface IRestService<T>
    {
        void ChangeaApiMap(string apiMap);
        Task<ObjectReturnRestService<T>> RefreshDataAsync();
        Task<ObjectReturnRestService<T>> SaveAsync(T item, bool isNewItem);
        Task<ObjectReturnRestService<T>> DeleteAsync(string id);
        Task<ObjectReturnRestService<T>> GenericSend(Dictionary<string, string> payload);
    }
}