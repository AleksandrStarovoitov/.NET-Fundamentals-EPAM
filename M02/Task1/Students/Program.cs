using System;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    {
        private static Random rnd;
        private static string vasyaPupkinName = "Vasya Pupkin";
        private static string ivanIvanovName = "Ivan Ivanov";
        private static string vladSokolovName = "Vlad Sokolov";
        private static string vasyaPupkinEmail = "vasya.pupkin@epam.com";
        private static string ivanIvanovEmail = "ivan.ivanov@epam.com";
        private static string vladSokolovEmail = "vlad.sokolov@epam.com";

        private static void Main(string[] args)
        {
            try
            {
                var subjects = new[] { "Maths", "PE", "History", "Art" };

                var students = new[]
                {
                    new Student(vasyaPupkinEmail, vasyaPupkinName),
                    new Student(ivanIvanovEmail, ivanIvanovName),
                    new Student(vladSokolovEmail, vladSokolovName),

                    new Student(vasyaPupkinEmail),
                    new Student(ivanIvanovEmail),
                    new Student(vladSokolovEmail),
                };

                var studentSubjectDict = new Dictionary<Student, string[]>();

                rnd = new Random();
                foreach (var student in students)
                {
                    studentSubjectDict[student] = new[]
                    {
                        subjects[rnd.Next(subjects.Length)],
                        subjects[rnd.Next(subjects.Length)],
                        subjects[rnd.Next(subjects.Length)],
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
