using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M03_Task1
{
    internal class DoubleChars
    {
        public static string GetDoubleCharString(string first, string second)
        {
            if (String.IsNullOrEmpty(first))
            {
                throw new ArgumentException("First string is null or empty", nameof(first));
            }

            if (String.IsNullOrEmpty(second))
            {
                throw new ArgumentException("Second string is null or empty", nameof(second));
            }

            var hashSet = new HashSet<char>(second.Where(c => !Char.IsWhiteSpace(c)));
            var sb = new StringBuilder();

            foreach (var c in first)
            {
                sb.Append(hashSet.Contains(c) ? $"{c}{c}" : c.ToString());
            }

            return sb.ToString();
        }
    }
}
