using System.Collections.Generic;
using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Grade> Grades { get; set; } = null!;
        public List<Homework> Homework { get; set; } = null!;
        public List<Attendance> Attendances { get; set; } = null!;
    }
}