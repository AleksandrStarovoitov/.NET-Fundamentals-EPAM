using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : BaseWithIncludeController<Attendance>
    {
        public AttendancesController(IAttendanceRepository repository) : base(repository) { }
    }
}