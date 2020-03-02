using System.Linq;
using ClassLibrary.BL.Interfaces.Reporting;
using ClassLibrary.BL.Reporting;
using ClassLibrary.DAL;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.BL.Services
{
    public class ReportService
    {
        private readonly IReportGenerator reportGenerator;
        private readonly UniversityContext context;

        public ReportService(IReportGenerator reportGenerator, UniversityContext context)
        {
            this.reportGenerator = reportGenerator;
            this.context = context;
        }

        public Report GenerateReportByLessonId(int lessonId)
        {
            var results = context.Attendances
                .Include(a => a.LessonInSchedule)
                .ToList()
                .Where(a => a.LessonInSchedule.LessonId == lessonId);

            return reportGenerator.GenerateReport(results);
        }

        public Report GenerateReportByStudentId(int studentId)
        {
            var results = context.Attendances
                .Where(a => a.StudentId == studentId);

            return reportGenerator.GenerateReport(results);
        }
    }
}