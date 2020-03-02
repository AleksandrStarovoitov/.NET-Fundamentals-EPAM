using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Attendance : IEntity
    {
        public int Id { get; set; }
        public bool IsPresent { get; set; }

        public int LessonInScheduleId { get; set; }
        public LessonInSchedule? LessonInSchedule { get; set; }
        
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, LessonInScheduleId: {LessonInScheduleId}, StudentId: {StudentId}, IsPresent: {IsPresent}";
        }
    }
}