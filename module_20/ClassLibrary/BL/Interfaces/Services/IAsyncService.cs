using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.BL.Interfaces.Services
{
    public interface IAsyncService<T> where T : class, IEntity
    {
        Task<List<T>> GetAllAsync(); // TODO IReadOnlyList?
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
