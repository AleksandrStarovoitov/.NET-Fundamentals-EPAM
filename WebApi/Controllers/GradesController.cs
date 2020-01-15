using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : BaseWithIncludeController<Grade> 
    {
        public GradesController(IGradeRepository repository) : base(repository) { }
    }
}