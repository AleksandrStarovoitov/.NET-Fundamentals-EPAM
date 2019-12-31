using System;

namespace ConsoleApp
{
    internal class Student
    {
        public string student;
        public string test;
        public DateTime date;
        public byte mark;

        public override string ToString()
        {
            return $"{student}\t{test}\t{date}\t{mark}";
        }
    }
}
