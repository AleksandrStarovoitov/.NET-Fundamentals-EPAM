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
    internal static class Program
    {
        private const string JsonPath = "ConsoleApp.Resources.students.json";
        private const string DateFormat = "dd/MM/yyyy";
        private const string Name = "name", Mark = "mark", Test = "test", Date = "date";
        
        public static void Main(string[] args)
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

                var students = ProcessInput(input, parsedStudents);

                Console.WriteLine("Student\tTest\tDate\tMark");

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }

        public static IEnumerable<Student> ProcessInput(string input, IEnumerable<Student> parsedStudents)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input is null or whitespace");
            }

            var regex = @"^((-[a-zA-Z]+ +[a-zA-Z0-9/]+ +)*(-[a-zA-Z]+ +[a-zA-Z0-9/]+)( +-sort +[a-z]+ +(a|de)sc+){0,1})$";
            if (!Regex.IsMatch(input, regex))
            {
                throw new ArgumentException("Invalid input");
            }

            var splitInput = input.Split('-').Where(s => s.Any());
            var splitInputList = splitInput.ToList();

            foreach (var flag in splitInputList)
            {
                parsedStudents = ProcessSearchCriteria(flag, parsedStudents);
            }

            return parsedStudents;
        }

        private static IEnumerable<Student> ProcessSearchCriteria(string flag, IEnumerable<Student> students)
        {
            var flagValuePair = flag.Split(' ').Where(s => s.Any()).ToArray();

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
