using System.ComponentModel.DataAnnotations;
using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Grade : IEntity
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public byte Mark { get; set; }
        
        public int LessonInScheduleId { get; set; }
        public LessonInSchedule? LessonInSchedule { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}