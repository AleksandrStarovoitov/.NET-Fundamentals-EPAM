using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    public class Grade
    {
        public byte Mark { get; set; }
        
        public int LessonInScheduleId { get; set; }
        public LessonInSchedule LessonInSchedule { get; set; } = null!;

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}
