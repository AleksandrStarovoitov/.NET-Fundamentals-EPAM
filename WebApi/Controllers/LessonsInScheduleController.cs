using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsInScheduleController : BaseWithIncludeController<LessonInSchedule>
    {
        public LessonsInScheduleController(ILessonInScheduleRepository repository) : base(repository) { }
    }
}