using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : BaseController<Lesson>
    {
        public LessonsController(ILessonService service) : base(service) { }
    }
}