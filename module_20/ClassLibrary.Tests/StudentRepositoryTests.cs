using ClassLibrary.BL.Model;
using ClassLibrary.DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ClassLibrary.Tests
{
    public class StudentRepositoryTests
    {
        private DbContextOptionsBuilder<UniversityContext> builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder<UniversityContext>()
                .UseInMemoryDatabase("InMemory");
        }

        [Test]
        public void AddAsync_Student_AddsCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new StudentRepository(context);

            var student = new Student() { Name = "TestStudent1" };
            var res = repository.AddAsync(student).Result;

            Assert.That(res.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void UpdateAsync_Student_UpdatesCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new StudentRepository(context);

            var student = new Student() { Name = "TestStudent1" };
            var res = repository.AddAsync(student).Result;
            var studentFromDb = repository.GetByIdAsync(res.Id).Result;
            studentFromDb.Name = "ChangedName";
            var changedRes = repository.UpdateAsync(studentFromDb).Result;

            Assert.That(changedRes.Name, Is.EqualTo("ChangedName"));
        }

        [Test]
        public void DeleteAsync_Student_DeletesCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new StudentRepository(context);

            var student = new Student() { Name = "TestStudent1" };
            var res = repository.AddAsync(student).Result;
            repository.DeleteAsync(res.Id).Wait();
            var deletedStudent = repository.GetByIdAsync(res.Id).Result;

            Assert.That(deletedStudent, Is.EqualTo(null));
        }

        [Test]
        public void GetByIdAsync_Student_GetsCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new StudentRepository(context);

            var student = new Student() { Name = "TestStudent1" };
            var res = repository.AddAsync(student).Result;
            var studentFromDb = repository.GetByIdAsync(res.Id).Result;

            Assert.That(studentFromDb, Is.EqualTo(res));
        }

        [Test]
        public void GetAllAsync_Student_GetsAllCorrectly()
        {
            using var context = new UniversityContext(builder.Options);
            var repository = new StudentRepository(context);
            // From UniversityContext OnModelCreating
            var initialNumber = 4;

            var count = repository.GetAllAsync().Result.Count;

            Assert.That(count, Is.EqualTo(initialNumber));
        }
    }
}