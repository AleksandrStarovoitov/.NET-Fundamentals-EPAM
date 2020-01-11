using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Homework> Homeworks { get; set; }
        public List<Attendance> Attendace { get; set; }
    }
}
