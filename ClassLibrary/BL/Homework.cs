﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    public class Homework
    {
        public int Id { get; set; }
        public string? Value { get; set; } //TODO Nullable?
        
        public int LessonInScheduleId { get; set; }
        public LessonInSchedule LessonInSchedule { get; set; } = null!;

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}
