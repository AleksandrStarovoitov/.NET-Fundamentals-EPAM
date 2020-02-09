using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;

namespace ClassLibrary.BL.Services
{
    public abstract class EfWithIncludeService<TEntity, TRepository> : EfService<TEntity, TRepository>, IIncludeAsyncService<TEntity>
        where TEntity : class, IEntity
        where TRepository : IIncludeAsyncRepository<TEntity>
    {
        protected EfWithIncludeService(TRepository repository) : base(repository) { }
        
        public Task<TEntity> GetByIdWithIncludeAsync(int id)
        {
            return repository.GetByIdWithIncludeAsync(id);
        }
    }
}