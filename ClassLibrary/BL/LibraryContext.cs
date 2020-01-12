using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL
{
    public class LibraryContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonInSchedule> LessonsInSchedule { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public LibraryContext()
        {
            Database.EnsureDeleted(); //TODO
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=University;Integrated Security=True; Connect Timeout=10"); //TODO Settings

        //TODO Custom initialization logic?
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher() { Id = 1, Name = "Jon Favreau" },
                new Teacher() { Id = 2, Name = "Robert Downey Jr." },
                new Teacher() { Id = 3, Name = "Benedict Cumberbatch" },
                new Teacher() { Id = 4, Name = "Scarlett Johansson" });

            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = 1, Name = "Tom Holland" },
                new Student() { Id = 2, Name = "Zendaya Coleman" },
                new Student() { Id = 3, Name = "Paul Rudd" },
                new Student() { Id = 4, Name = "Chris Hemsworth" });

            modelBuilder.Entity<Lesson>().HasData(
                new Lesson() { Id = 1, Name = "Maths" },
                new Lesson() { Id = 2, Name = "IT" },
                new Lesson() { Id = 3, Name = "English" },
                new Lesson() { Id = 4, Name = "PE" });

            modelBuilder.Entity<LessonInSchedule>().HasData(
                new LessonInSchedule() { Id = 1, LessonId = 2, Datetime = new DateTime(2020, 1, 1, 12, 0, 0), TeacherId = 1 },
                new LessonInSchedule() { Id = 2, LessonId = 2, Datetime = new DateTime(2020, 1, 1, 14, 0, 0), TeacherId = 1 },
                new LessonInSchedule() { Id = 3, LessonId = 1, Datetime = new DateTime(2020, 1, 1, 16, 0, 0), TeacherId = 2 },
                new LessonInSchedule() { Id = 4, LessonId = 3, Datetime = new DateTime(2020, 1, 2, 10, 0, 0), TeacherId = 3 },
                new LessonInSchedule() { Id = 5, LessonId = 4, Datetime = new DateTime(2020, 1, 2, 12, 0, 0), TeacherId = 4 },
                new LessonInSchedule() { Id = 6, LessonId = 1, Datetime = new DateTime(2020, 1, 3, 14, 0, 0), TeacherId = 4 });

            modelBuilder.Entity<Homework>().HasData(
                new Homework() { Id = 1, LessonInScheduleId = 1, StudentId = 1, Value = "Homework1" },
                new Homework() { Id = 2, LessonInScheduleId = 1, StudentId = 2, Value = "Homework2" },
                new Homework() { Id = 3, LessonInScheduleId = 1, StudentId = 3, Value = "Homework3" },
                new Homework() { Id = 4, LessonInScheduleId = 2, StudentId = 4, Value = "Homework4" });

            modelBuilder.Entity<Attendance>().HasData(
                new Attendance() { Id = 1, LessonInScheduleId = 1, StudentId = 1, IsPresent = true },
                new Attendance() { Id = 2, LessonInScheduleId = 1, StudentId = 2, IsPresent = true },
                new Attendance() { Id = 3, LessonInScheduleId = 1, StudentId = 3, IsPresent = true },
                new Attendance() { Id = 4, LessonInScheduleId = 1, StudentId = 4, IsPresent = true },
                new Attendance() { Id = 5, LessonInScheduleId = 2, StudentId = 1, IsPresent = false },
                new Attendance() { Id = 6, LessonInScheduleId = 2, StudentId = 2, IsPresent = true },
                new Attendance() { Id = 7, LessonInScheduleId = 2, StudentId = 3, IsPresent = false },
                new Attendance() { Id = 8, LessonInScheduleId = 2, StudentId = 4, IsPresent = true });

            modelBuilder.Entity<Grade>().HasData(
                new Grade() { Id = 1, StudentId = 1, LessonInScheduleId = 1, Mark = 0 },
                new Grade() { Id = 2, StudentId = 2, LessonInScheduleId = 1, Mark = 4 },
                new Grade() { Id = 3, StudentId = 3, LessonInScheduleId = 1, Mark = 5 },
                new Grade() { Id = 4, StudentId = 4, LessonInScheduleId = 1, Mark = 4 },
                new Grade() { Id = 5, StudentId = 1, LessonInScheduleId = 2, Mark = 0 },
                new Grade() { Id = 6, StudentId = 2, LessonInScheduleId = 2, Mark = 5 },
                new Grade() { Id = 7, StudentId = 3, LessonInScheduleId = 2, Mark = 0 },
            new Grade() { Id = 8, StudentId = 4, LessonInScheduleId = 2, Mark = 3 });
        }
    }
}
