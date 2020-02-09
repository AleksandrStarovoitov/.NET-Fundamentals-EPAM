using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;

namespace ClassLibrary.BL.Services
{
    public abstract class EfService<TEntity, TRepository> : IAsyncService<TEntity>
        where TEntity : class, IEntity
        where TRepository : IAsyncRepository<TEntity>
    {
        protected readonly TRepository repository;

        protected EfService(TRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await repository.AddAsync(entity);
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
        
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            //TODO If no entity
            return await repository.UpdateAsync(entity);
        }
    }
}