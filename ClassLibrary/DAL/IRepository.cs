using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAllAsync(); // TODO IReadOnlyList?
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
