using ClassLibrary.BL.Model;
using ClassLibrary.DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : BaseController<Attendance>
    {
        public AttendancesController(IAttendanceRepository repository) : base(repository) { }
    }
}