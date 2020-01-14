using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Grade : IEntity
    {
        public int Id { get; set; }
        public byte Mark { get; set; }
        
        public int LessonInScheduleId { get; set; }
        public LessonInSchedule LessonInSchedule { get; set; } = null!;

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}