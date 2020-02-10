using ClassLibrary.BL.Reporting;
using ClassLibrary.DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Reporting
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlReportsController : ReportsController<XmlReportGenerator>
    {
        public XmlReportsController(XmlReportGenerator reportGenerator, UniversityContext context) : base(reportGenerator, context) { }
    }
}