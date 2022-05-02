using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Services
{
    interface IService<T,D> 
    {
         IAsyncEnumerable<T> Get();
         Task<T> GetByID(int Id);
        Task<T> Add(D entity);
        Task<T> UpdateById(D entity, int id);
        Task DeleteById(int Id);
    }
}
