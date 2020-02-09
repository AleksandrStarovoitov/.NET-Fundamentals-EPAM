using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.DAL
{
    public abstract class EfWithIncludeRepository<TEntity, TContext> : EfRepository<TEntity, TContext>, IIncludeAsyncRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected EfWithIncludeRepository(TContext context) : base(context) { }

        protected async Task<TEntity> GetByIdWithIncludeInternalAsync(int id, params Expression<Func<TEntity, object>>[] navigationPropertyPaths)
        {
            foreach (var path in navigationPropertyPaths)
            {
                context.Set<TEntity>().Include(path).ToList();
            }

            return await context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public abstract Task<TEntity> GetByIdWithIncludeAsync(int id);
    }
}