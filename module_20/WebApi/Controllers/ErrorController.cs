using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var exHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = exHandlerFeature?.Error;

            if (ex is DbUpdateException)
            {
                return Problem(title: ex.InnerException?.Message ?? ex.Message); 
            }

            return Problem();
        }
    }
}
