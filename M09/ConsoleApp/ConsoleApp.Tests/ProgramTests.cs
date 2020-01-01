using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ConsoleApp.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private const string DateFormat = "dd/MM/yyyy";
        private const string JsonPath = "ConsoleApp.Resources.students.json";
        private static List<Student> parsedStudents;

        [SetUp]
        public void SetUp()
        {
            var assembly = Assembly.GetAssembly(typeof(ConsoleApp.Program));

            using (var sr = new StreamReader(assembly.GetManifestResourceStream(JsonPath) ??
                                             throw new InvalidOperationException()))
            {
                var jsonString = sr.ReadToEnd();

                parsedStudents = JsonConvert.DeserializeObject<List<Student>>(jsonString, new JsonSerializerSettings
                {
                    DateFormatString = DateFormat
                });
            }
        }

        [Test]
        public void ProcessInput_NullInput_ThrowsArgumentNullException()
        {
            Assert.That(() => Program.ProcessInput(null, parsedStudents),
                Throws.ArgumentException.
                    With.Message.
                    EqualTo("Input is null or whitespace"));
        }

        [Test]
        public void ProcessInput_InvalidInputs_ThrowsArgumentException()
        {
            var tooManyArguments = "-test 2 2 3 -name Ivan";
            var noFlag = "test 5";
            var noFlagName = "- 2";
            var noFlagValue = "-test";
            var invalidFlagName = "-test= Maths";
            var invalidSort = "-test Maths -sort test desssc";

            var expectedMessage = "Invalid input";
            Assert.Multiple(() =>
            {
                Assert.That(() => Program.ProcessInput(tooManyArguments, parsedStudents),
                    Throws.ArgumentException.
                        With.Message.
                        EqualTo(expectedMessage));
                Assert.That(() => Program.ProcessInput(noFlag, parsedStudents),
                    Throws.ArgumentException.
                        With.Message.
                        EqualTo(expectedMessage));
                Assert.That(() => Program.ProcessInput(noFlagName, parsedStudents),
                    Throws.ArgumentException.
                        With.Message.
                        EqualTo(expectedMessage));
                Assert.That(() => Program.ProcessInput(noFlagValue, parsedStudents),
                    Throws.ArgumentException.
                        With.Message.
                        EqualTo(expectedMessage));
                Assert.That(() => Program.ProcessInput(invalidFlagName, parsedStudents),
                    Throws.ArgumentException.
                        With.Message.
                        EqualTo(expectedMessage));
                Assert.That(() => Program.ProcessInput(invalidSort, parsedStudents),
                    Throws.ArgumentException.
                        With.Message.
                        EqualTo(expectedMessage));
            });
        }

        [Test]
        public void ProcessInput_Search_Criteria_ThrowsArgumentException()
        {
            var inputString = "-Search Ivan";

            Assert.That(() => Program.ProcessInput(inputString, parsedStudents),
                Throws.ArgumentException.
                    With.Message.
                    EqualTo("Invalid search criteria"));
        }

        [Test]
        public void ProcessInput_InvalidMarkValue_ThrowsArgumentException()
        {
            var invalidMinMark = "-minmark wrong";
            var invalidMaxMark = "-maxmark wrong";

            var expectedMessage = "Invalid mark value";
            Assert.Multiple(() =>
            {
                Assert.That(() => Program.ProcessInput(invalidMinMark, parsedStudents),
                    Throws.ArgumentException.
                        With.Message.
                        EqualTo(expectedMessage));
                Assert.That(() => Program.ProcessInput(invalidMaxMark, parsedStudents),
                    Throws.ArgumentException.
                        With.Message.
                        EqualTo(expectedMessage));
            });
        }

        [Test]
        public void ProcessInput_InvalidSearchCriteria_ThrowsArgumentException()
        {
            var inputString = "-tes Maths";

            Assert.That(() => Program.ProcessInput(inputString, parsedStudents),
                Throws.ArgumentException.
                    With.Message.
                    EqualTo("Invalid search criteria"));
        }

        [Test]
        public void ProcessInput_InvalidSortCriteria_ThrowsArgumentException()
        {
            var inputString = "-test Maths -sort tests asc";

            Assert.That(() => Program.ProcessInput(inputString, parsedStudents),
                Throws.ArgumentException.
                    With.Message.
                    EqualTo("Invalid sort criteria"));
        }

        [Test]
        public void ProcessInput_Minmark_FiltersCorrectly()
        {
            var inputString = "-minmark 3";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s => s.mark >= 3);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_Maxmark_FiltersCorrectly()
        {
            var inputString = "-maxmark 4";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s => s.mark <= 4);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_Name_FiltersCorrectly()
        {
            var inputString = "-name Ivan";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s => Regex.IsMatch(s.student, "Ivan"));

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_DateFrom_FiltersCorrectly()
        {
            var inputString = "-datefrom 20/11/2012";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s => s.date > new DateTime(2012,11,20));

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_DateTo_FiltersCorrectly()
        {
            var inputString = "-dateto 28/11/2012";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s => s.date < new DateTime(2012, 11, 28));

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_Test_FiltersCorrectly()
        {
            var inputString = "-test Maths";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s => s.test.Equals("Maths"));

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_AllCriterias_FiltersCorrectly()
        {
            var inputString = "-minmark 2 -name Ivan -maxmark 4 -test Maths -dateto 28/11/2012 -datefrom 20/11/2012";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s =>
                Regex.IsMatch(s.student, "Ivan") &&
                s.test.Equals("Maths") && s.mark >= 2 && s.mark <= 4 &&
                s.date < new DateTime(2012, 11, 28) &&
                s.date > new DateTime(2012, 11, 20));

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_MinmarkSortMarkAsc_FiltersCorrectly()
        {
            var inputString = "-minmark 3 -sort mark asc";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s => s.mark >= 3).OrderBy(s => s.mark);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_MinmarkSortMarkDesc_FiltersCorrectly()
        {
            var inputString = "-minmark 3 -sort mark desc";

            var result = Program.ProcessInput(inputString, parsedStudents).ToList();

            var expected = parsedStudents.Where(s => s.mark >= 3).OrderByDescending(s => s.mark);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}