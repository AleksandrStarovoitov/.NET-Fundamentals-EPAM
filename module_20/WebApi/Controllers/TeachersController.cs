using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : BaseController<Teacher>
    {
        public TeachersController(ITeacherRepository repository) : base(repository) { }
    }
}