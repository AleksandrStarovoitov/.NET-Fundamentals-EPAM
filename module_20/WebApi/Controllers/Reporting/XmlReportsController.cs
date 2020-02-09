using ClassLibrary.BL.Reporting;
using ClassLibrary.DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Reporting
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlReportsController : ReportsController<XmlReportWriter>
    {
        public XmlReportsController(XmlReportWriter reportWriter, UniversityContext context) : base(reportWriter, context) { }
    }
}