using System;
using System.Linq;
using ClassLibrary.BL;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryContext())
            {
                context.Grades
                    .Include(g => g.Student)
                    .Include(g => g.LessonInSchedule).
                        ThenInclude(l => l.Lesson)
                    .ToList();

                foreach (var g in context.Grades)
                {
                    Console.WriteLine($"{g.Id}: {g.Student.Name} - {g.Mark} ({g.LessonInSchedule.Lesson.Name}, {g.LessonInSchedule.Datetime})");
                }
            }
        }
    }
}
