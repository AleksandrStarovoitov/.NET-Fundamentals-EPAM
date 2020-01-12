using System.Collections.Generic;

namespace ClassLibrary.BL.Model
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<LessonInSchedule> LessonsInSchedule { get; set; } = null!;
    }
}