using System.Threading.Tasks;

namespace ClassLibrary.BL.Interfaces.Repositories
{
    public interface IGetWithIncludeAsyncRepository<T> where T : class, IEntity
    {
        Task<T> GetByIdWithIncludeAsync(int id);
    }
}