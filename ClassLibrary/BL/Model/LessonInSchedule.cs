using System;
using System.Collections.Generic;

namespace ClassLibrary.BL.Model
{
    public class LessonInSchedule : IEntity
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }

        public List<Grade> Grades { get; set; } = null!;

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}