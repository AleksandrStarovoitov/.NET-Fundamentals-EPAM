using System.Collections.Generic;
using System.Text.Json.Serialization;
using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public List<Grade> Grades { get; set; } = null!;
        [JsonIgnore]
        public List<Homework> Homework { get; set; } = null!;
        [JsonIgnore]
        public List<Attendance> Attendances { get; set; } = null!;
    }
}