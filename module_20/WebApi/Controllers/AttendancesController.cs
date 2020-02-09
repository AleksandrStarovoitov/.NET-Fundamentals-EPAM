using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : BaseWithIncludeController<Attendance>
    {
        public AttendancesController(IAttendanceService service) : base(service) { }
    }
}