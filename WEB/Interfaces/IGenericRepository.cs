using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task AddAsync(T model);
        Task<List<T>> GetItemsAsync();
        Task<T> GetItemByIdAsync(int id);
        Task RemoveAsync(int id);

        Task Complete();
    }
}