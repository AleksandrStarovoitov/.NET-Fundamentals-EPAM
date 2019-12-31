using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Student
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
