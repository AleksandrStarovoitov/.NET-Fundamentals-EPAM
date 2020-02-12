using ClassLibrary.BL.Interfaces.Reporting;
using ClassLibrary.BL.Reporting;
using ClassLibrary.DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Reporting
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlReportsController : ReportsController
    {
        public XmlReportsController(IXmlReportGenerator reportGenerator, UniversityContext context) : base(reportGenerator, context) { }
    }
}