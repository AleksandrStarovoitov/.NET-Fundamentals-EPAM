using System.Threading.Tasks;

namespace ClassLibrary.BL.Interfaces.Services
{
    public interface IGetWithIncludeAsyncRepository<T> where T : class, IEntity
    {
        Task<T> GetByIdWithIncludeAsync(int id);
    }
}