using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary.BL
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<LessonInSchedule> LessonsInSchedule { get; set; } = null!;
    }
}
