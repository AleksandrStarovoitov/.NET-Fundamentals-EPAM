using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Attendance : IEntity
    {
        public int Id { get; set; }
        public bool IsPresent { get; set; }

        public int LessonInScheduleId { get; set; }
        public LessonInSchedule LessonInSchedule { get; set; } = null!;
        
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public override string ToString()
        {
            return $"Id: {Id}, LessonInScheduleId: {LessonInScheduleId}, StudentId: {StudentId}, IsPresent: {IsPresent}"; // TODO
        }
    }
}