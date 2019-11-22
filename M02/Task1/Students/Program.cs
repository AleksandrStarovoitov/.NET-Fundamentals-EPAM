using System;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    {
        private static Random rnd;

        private static void Main(string[] args)
        {
            var subjects = new[] {"Maths", "PE", "History", "Art"};

            try
            {
                var students = new[]
                {
                    new Student("vasya.pupkin@epam.com", "Vasya Pupkin"),
                    new Student("ivan.ivanov@epam.com", "Ivan Ivanov"),
                    new Student("vlad.sokolov@epam.com", "Vlad Sokolov"),

                    new Student("vasya.pupkin@epam.com"),
                    new Student("ivan.ivanov@epam.com"),
                    new Student("vlad.sokolov@epam.com"),
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
