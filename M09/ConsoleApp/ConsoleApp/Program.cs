using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        private const string jsonPath = "ConsoleApp.Resources.students.json";

        static void Main(string[] args)
        {
            //TODO
            var input = "-name Ivan -minmark 3 -maxmark 5 -datefrom 20/11/2012 -dateto 20/12/2012 -test Maths";
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream =
                new StreamReader(assembly.GetManifestResourceStream("ConsoleApp.Resources.students.json") ??
                                 throw new InvalidOperationException()))
            {
                var jsonString = stream.ReadToEnd();

                var parsedStudents = JsonConvert.DeserializeObject<List<Student>>(jsonString, new JsonSerializerSettings
                {
                    DateFormatString = "dd/mm/yyyy"
                });
                
                Console.WriteLine("Hello! Please input your criteria:");
                
                //TODO
                Console.WriteLine(input); 
                //var input = Console.ReadLine();
                var splitInput = input.Split('-');

                IEnumerable<Student> students = parsedStudents;
                foreach (var flag in splitInput)
                {
                    //TODO
                    if (!flag.Any())
                    {
                        continue;
                    }
                    students = ProcessSearchCriteria(flag, students);
                }

                //TODO
                Console.WriteLine("Student\tTest\tDate\tMark");

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }

        private static IEnumerable<Student> ProcessSearchCriteria(string flag, IEnumerable<Student> students)
        {
            var flagValuePair = flag.Split(' ');

            if (flagValuePair.Length < 2)
            {
                throw new ArgumentException("Invalid input.");
            }

            switch (flagValuePair[0])
            {
                case "name":
                    return students.Where(s => s.student.Equals(flagValuePair[1]));
                case "minmark":
                    var minMark = Int32.Parse(flagValuePair[1]);
                    return students.Where(s => s.mark > minMark);
                case "maxmark":
                    var maxMark = Int32.Parse(flagValuePair[1]);
                    return students.Where(s => s.mark < maxMark);
                case "datefrom":
                    //TODO datetime format
                    var dateFrom = DateTime.Parse(flagValuePair[1]);
                    return students.Where(s => s.date > dateFrom);
                case "dateto":
                    var dateTo = DateTime.Parse(flagValuePair[1]);
                    return students.Where(s => s.date < dateTo);
                case "test":
                    return students.Where(s => s.test.Equals(flagValuePair[1]));
                default:
                    throw new ArgumentException("Invalid input.");
            }
        }
    }
}
