using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    class Attendance
    {
        public int Id { get; set; }
        public bool IsPresent { get; set; }

        public int LessonInScheduleId { get; set; }
        public LessonInSchedule LessonInSchedule { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
