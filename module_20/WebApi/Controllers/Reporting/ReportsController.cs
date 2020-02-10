using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Services;
using ClassLibrary.DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Reporting
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ReportsController<TReportGenerator> : ControllerBase 
        where TReportGenerator : IReportGenerator
    {
        private readonly ReportService reportService;

        protected ReportsController(TReportGenerator reportGenerator, UniversityContext context)
        {
            reportService = new ReportService(reportGenerator, context);
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