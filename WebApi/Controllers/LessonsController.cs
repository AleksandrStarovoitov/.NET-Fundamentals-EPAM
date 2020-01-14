using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : BaseController<Lesson>
    {
        public LessonsController(ILessonRepository repository) : base(repository) { }
    }
}