using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    class LessonInSchedule
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
