using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<LessonInSchedule> LessonsInSchedule { get; set; }
    }
}
