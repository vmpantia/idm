using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Domain.Contractors
{
    public interface IRepositoryService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(object id);
        Task Add(T entity);
        Task Update(object id, object model);
        Task Delete(object id);
    }
}
