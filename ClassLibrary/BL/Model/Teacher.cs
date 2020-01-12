using System.Collections.Generic;

namespace ClassLibrary.BL.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<LessonInSchedule> LessonsInSchedule { get; set; } = null!;
    }
}