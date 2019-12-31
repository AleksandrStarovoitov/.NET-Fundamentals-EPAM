using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        private const string jsonPath = "ConsoleApp.Resources.students.json";

        static void Main(string[] args)
        {
            // -name Ivan -minmark 3 -maxmark 5 -datefrom 20/11/2012 -dateto 20/12/2012 -test Maths

            var serializer = new JsonSerializer();

            var assembly = Assembly.GetExecutingAssembly();

            using (var stream =
                new StreamReader(assembly.GetManifestResourceStream("ConsoleApp.Resources.students.json") ??
                                 throw new InvalidOperationException()))
            {
                var jsonString = stream.ReadToEnd();

                var definition = new[]
                {
                    new { student = "", test = "", date = new DateTime(), mark = 0 }
                };

                var students = JsonConvert.DeserializeAnonymousType(jsonString, definition, new JsonSerializerSettings
                {
                    DateFormatString = "dd/mm/yyyy"
                });
                
                Console.WriteLine("Hello! Please input your criteria:");

                var input = Console.ReadLine();
                var splitInput = input.Split('-');

                foreach (var flag in splitInput)
                {
                    ProcessSearchCriteria(flag);
                }
            }
        }

        private static void ProcessSearchCriteria(string flag)
        {
            throw new NotImplementedException();
        }
    }
}
