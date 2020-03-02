using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsInScheduleController : BaseWithIncludeController<LessonInSchedule>
    {
        public LessonsInScheduleController(ILessonInScheduleService service) : base(service) { }
    }
}