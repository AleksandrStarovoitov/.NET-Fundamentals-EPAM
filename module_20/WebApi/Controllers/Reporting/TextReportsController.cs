using ClassLibrary.BL.Reporting;
using ClassLibrary.DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Reporting
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextReportsController : ReportsController<TxtReportGenerator>
    {
        public TextReportsController(TxtReportGenerator reportGenerator, UniversityContext context) : base(reportGenerator, context) { }
    }
}