using System;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    {
        private static Random rnd;

        private static void Main(string[] args)
        {
            try
            {
                var subjects = new[] { "Maths", "PE", "History", "Art" };

                var vasyaPupkinName = "Vasya Pupkin";
                var ivanIvanovName = "Ivan Ivanov";
                var vladSokolovName = "Vlad Sokolov";
                var vasyaPupkinEmail = "vasya.pupkin@epam.com";
                var ivanIvanovEmail = "ivan.ivanov@epam.com";
                var vladSokolovEmail = "vlad.sokolov@epam.com";

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
