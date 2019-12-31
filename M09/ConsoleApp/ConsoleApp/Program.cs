using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ConsoleApp
{
    public static class Program
    {
        private const string JsonPath = "ConsoleApp.Resources.students.json";
        private const string DateFormat = "dd/MM/yyyy";
        private const string InvalidInputEx = "Invalid input.";
        private const string Name = "name", Mark = "mark", Test = "test", Date = "date";

        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream =
                new StreamReader(assembly.GetManifestResourceStream(JsonPath) ??
                                 throw new InvalidOperationException()))
            {
                var jsonString = stream.ReadToEnd();

                var parsedStudents = JsonConvert.DeserializeObject<List<Student>>(jsonString, new JsonSerializerSettings
                {
                    DateFormatString = DateFormat
                });

                Console.WriteLine("Hello! Please input your criteria:");

                var input = Console.ReadLine();
                var splitInput = input?.Split('-').Where(s => s.Any()) ?? throw new ArgumentException("No input");
                var splitInputList = splitInput.ToList();

                if (!splitInputList.Any())
                {
                    throw new ArgumentException("Invalid input");
                }

                IEnumerable<Student> students = parsedStudents;
                foreach (var flag in splitInputList)
                {
                    students = ProcessSearchCriteria(flag, students);
                }

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
                throw new ArgumentException("Arguments number < 2");
            }

            switch (flagValuePair[0])
            {
                case Name:
                    return students.Where(s => Regex.IsMatch(s.student, flagValuePair[1]));

                case "minmark":
                    if (Int32.TryParse(flagValuePair[1], out var minMark))
                    {
                        return students.Where(s => s.mark >= minMark);
                    }
                    throw new ArgumentException("Invalid mark value");

                case "maxmark":
                    if (Int32.TryParse(flagValuePair[1], out var maxMark))
                    {
                        return students.Where(s => s.mark <= maxMark);
                    }
                    throw new ArgumentException("Invalid mark value");

                case "datefrom":
                    var dateFrom = DateTime.ParseExact(flagValuePair[1], DateFormat, CultureInfo.InvariantCulture);
                    return students.Where(s => s.date > dateFrom);

                case "dateto":
                    var dateTo = DateTime.ParseExact(flagValuePair[1], DateFormat, CultureInfo.InvariantCulture);
                    return students.Where(s => s.date < dateTo);

                case Test:
                    return students.Where(s => s.test.Equals(flagValuePair[1]));

                case "sort":
                    return ProcessSortCriteria(flagValuePair, students);

                default:
                    throw new ArgumentException("Invalid search criteria");
            }
        }

        private static IEnumerable<Student> ProcessSortCriteria(string[] flagValuePair, IEnumerable<Student> students)
        {
            if (flagValuePair.Length < 3)
            {
                throw new ArgumentException(InvalidInputEx);
            }

            const string asc = "asc", desc = "desc";

            switch (flagValuePair[1])
            {
                case Name when flagValuePair[2].Equals(asc):
                    return students.OrderBy(s => s.student);
                case Name when flagValuePair[2].Equals(desc):
                    return students.OrderByDescending(s => s.student);

                case Mark when flagValuePair[2].Equals(asc):
                    return students.OrderBy(s => s.mark);
                case Mark when flagValuePair[2].Equals(desc):
                    return students.OrderByDescending(s => s.mark);

                case Test when flagValuePair[2].Equals(asc):
                    return students.OrderBy(s => s.test);
                case Test when flagValuePair[2].Equals(desc):
                    return students.OrderByDescending(s => s.test);

                case Date when flagValuePair[2].Equals(asc):
                    return students.OrderBy(s => s.date);
                case Date when flagValuePair[2].Equals(desc):
                    return students.OrderByDescending(s => s.date);

                default:
                    throw new ArgumentException("Invalid sort criteria");
            }
        }
    }
}
