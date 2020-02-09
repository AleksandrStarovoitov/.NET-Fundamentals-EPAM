using ClassLibrary.BL.Reporting;
using ClassLibrary.DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Reporting
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextReportsController : ReportsController<TxtReportWriter>
    {
        public TextReportsController(TxtReportWriter reportWriter, UniversityContext context) : base(reportWriter, context) { }
    }
}