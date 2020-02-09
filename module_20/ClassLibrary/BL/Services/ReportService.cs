using System.Linq;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Reporting;
using ClassLibrary.DAL;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.BL.Services
{
    public class ReportService
    {
        private readonly IReportWriter reportWriter;
        private readonly UniversityContext context;

        public ReportService(IReportWriter reportWriter, UniversityContext context)
        {
            this.reportWriter = reportWriter;
            this.context = context;
        }

        public Report GenerateReportByLessonId(int lessonId)
        {
            var results = context.Attendances
                .Include(a => a.LessonInSchedule)
                .ToList()
                .Where(a => a.LessonInSchedule.LessonId == lessonId);

            return reportWriter.GenerateReport(results);
        }

        public Report GenerateReportByStudentId(int studentId)
        {
            var results = context.Attendances
                .Where(a => a.StudentId == studentId);

            return reportWriter.GenerateReport(results);
        }
    }
}