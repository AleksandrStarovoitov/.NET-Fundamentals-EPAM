using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
        where TEntity : class, IEntity
    {
        private readonly IAsyncRepository<TEntity> repository;

        public BaseController(IAsyncRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetById(int id)
        {
            var entity = await repository.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TEntity entity)
        {
            //TODO If no entity
            await repository.UpdateAsync(entity);

            return Ok();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Create(TEntity entity)
        {
            await repository.AddAsync(entity);
            return CreatedAtAction("Create", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await repository.DeleteAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}