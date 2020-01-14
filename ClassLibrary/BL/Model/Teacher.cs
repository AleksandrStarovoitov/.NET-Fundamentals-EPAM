using System.Collections.Generic;
using System.Text.Json.Serialization;
using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public List<LessonInSchedule> LessonsInSchedule { get; set; } = null!;
    }
}