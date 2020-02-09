using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Services;
using ClassLibrary.DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Reporting
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ReportsController<TReportWriter> : ControllerBase 
        where TReportWriter : IReportWriter
    {
        private readonly ReportService reportService;

        protected ReportsController(TReportWriter reportWriter, UniversityContext context)
        {
            reportService = new ReportService(reportWriter, context);
        }

        [HttpGet("ByStudentId/{id}")]
        public async Task<IActionResult> GetXmlReportByStudentId(int id)
        {
            var report = reportService.GenerateReportByStudentId(id);
            return this.Content(report.Content, report.ContentType);
        }

        [HttpGet("ByLessonId/{id}")]
        public async Task<IActionResult> GetXmlReportByLessonId(int id)
        {
            var report = reportService.GenerateReportByLessonId(id);
            return this.Content(report.Content, report.ContentType);
        }
    }
}