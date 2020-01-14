using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : BaseController<Attendance>
    {
        public AttendancesController(IAttendanceRepository repository) : base(repository) { }

        // GET: api/[controller]/include/5
        [HttpGet("include/{id}")]
        public async Task<ActionResult<Attendance>> GetWithInclude(int id)
        {
            var entity = await (repository as IAttendanceRepository)?.GetByIdWithStudentAndLessonAsync(id); // TODO null check

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }
    }
}