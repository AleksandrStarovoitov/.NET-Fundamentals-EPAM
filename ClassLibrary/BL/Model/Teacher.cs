using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<LessonInSchedule> LessonsInSchedule { get; set; } = null!;
    }
}
