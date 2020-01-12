using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Grade> Grades { get; set; } = null!;
        public List<Homework> Homework { get; set; } = null!;
        public List<Attendance> Attendances { get; set; } = null!;
    }
}
