using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : BaseWithIncludeController<Homework>
    {
        public HomeworkController(IHomeworkService service) : base(service) { }
    }
}