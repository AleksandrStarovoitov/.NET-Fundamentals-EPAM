using ClassLibrary.BL.Model;
using ClassLibrary.DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ClassLibrary.Tests
{
    public class AttendanceRepositoryTests
    {
        private DbContextOptionsBuilder<UniversityContext> builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder<UniversityContext>()
                .UseInMemoryDatabase("InMemory");
        }

        [Test]
        public void AddAsync_Attendance_AddsCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new AttendanceRepository(context);

            var attendance = new Attendance() { StudentId = 1, LessonInScheduleId = 1, IsPresent = true };
            var res = repository.AddAsync(attendance).Result;

            Assert.That(res.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void UpdateAsync_Attendance_UpdatesCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new AttendanceRepository(context);

            var attendance = new Attendance() { StudentId = 1, LessonInScheduleId = 1, IsPresent = true };
            var res = repository.AddAsync(attendance).Result;
            var attendanceFromDb = repository.GetByIdAsync(res.Id).Result;
            attendanceFromDb.StudentId = 2;
            var changedRes = repository.UpdateAsync(attendanceFromDb).Result;

            Assert.That(changedRes.StudentId, Is.EqualTo(2));
        }

        [Test]
        public void DeleteAsync_Attendance_DeletesCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new AttendanceRepository(context);

            var attendance = new Attendance() { StudentId = 1, LessonInScheduleId = 1, IsPresent = true };
            var res = repository.AddAsync(attendance).Result;
            repository.DeleteAsync(res.Id).Wait();
            var deletedAttendance = repository.GetByIdAsync(res.Id).Result;

            Assert.That(deletedAttendance, Is.EqualTo(null));
        }

        [Test]
        public void GetByIdAsync_Attendance_GetsCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new AttendanceRepository(context);

            var attendance = new Attendance() { StudentId = 1, LessonInScheduleId = 1, IsPresent = true };
            var res = repository.AddAsync(attendance).Result;
            var attendanceFromDb = repository.GetByIdAsync(res.Id).Result;

            Assert.That(attendanceFromDb, Is.EqualTo(res));
        }

        [Test]
        public void GetAllAsync_Attendance_GetsAllCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new AttendanceRepository(context);
            // From UniversityContext OnModelCreating
            var initialNumber = 8;

            var count = repository.GetAllAsync().Result.Count;

            Assert.That(count, Is.EqualTo(initialNumber));
        }

        [Test]
        public void GetWithIncludeAsync_Attendance_GetsCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new AttendanceRepository(context);

            var attendance = new Attendance() { StudentId = 1, LessonInScheduleId = 1, IsPresent = true };
            var res = repository.AddAsync(attendance).Result;
            var attendanceFromDb = repository.GetByIdWithIncludeAsync(res.Id).Result;
            
            Assert.Multiple(() =>
            {
                Assert.That(attendanceFromDb.LessonInSchedule, Is.Not.EqualTo(null));
                Assert.That(attendanceFromDb.Student, Is.Not.EqualTo(null));
            });
        }
    }
}