using System;
using System.Globalization;
using System.Linq;
using ClassLibrary.BL.Model;
using ClassLibrary.BL.Reporting;
using ClassLibrary.DAL;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=University;Integrated Security=True; Connect Timeout=10");

            using (var context = new UniversityContext(optionsBuilder.Options))
            {
                //context.Grades
                //    .Include(g => g.Student)
                //    .Include(g => g.LessonInSchedule).
                //        ThenInclude(l => l.Lesson)
                //    .ToList();

                //foreach (var g in context.Grades)
                //{
                //    Console.WriteLine($"{g.Id}: {g.Student.Name} - {g.Mark} ({g.LessonInSchedule.Lesson.Name}, {g.LessonInSchedule.Datetime})");
                //}
                //var studentRepo = new EfRepository<Student, UniversityContext>(context);
                //var student = studentRepo.GetAsync(1).Result;

                var reportManager = new ReportManager(new TxtReportWriter("report.txt"), context);
                reportManager.GenerateReportByStudentId(1);

                reportManager = new ReportManager(new XmlReportWriter("report.xml"), context);
                reportManager.GenerateReportByStudentId(1);
            }
        }
    }
}
