using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Homework : IEntity
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        
        public int LessonInScheduleId { get; set; }
        public LessonInSchedule? LessonInSchedule { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}