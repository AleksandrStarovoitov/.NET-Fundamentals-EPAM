using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public abstract class EfWithIncludeService<TEntity, TRepository> : EfService<TEntity, TRepository>, IIncludeAsyncService<TEntity>
        where TEntity : class, IEntity
        where TRepository : IIncludeAsyncRepository<TEntity>
    {
        protected EfWithIncludeService(TRepository repository, ILogger<EfWithIncludeService<TEntity, TRepository>> logger) : base(repository, logger) { }
        
        public Task<TEntity> GetByIdWithIncludeAsync(int id)
        {
            return repository.GetByIdWithIncludeAsync(id);
        }
    }
}