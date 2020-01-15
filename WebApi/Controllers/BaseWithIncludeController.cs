using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseWithIncludeController<TEntity> : BaseController<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IIncludeAsyncRepository<TEntity> repository;

        public BaseWithIncludeController(IIncludeAsyncRepository<TEntity> repository) : base(repository)
        {
            this.repository = repository;
        }

        // GET: api/[controller]/include/5
        [HttpGet("include/{id}")]
        public async Task<ActionResult<TEntity>> GetWithInclude(int id)
        {
            var entity = await repository.GetByIdWithIncludeAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }
    }
}