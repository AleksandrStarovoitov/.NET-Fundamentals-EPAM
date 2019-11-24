using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M03_Task1
{
    internal static class DoubleChars
    {
        public static string GetDoubleCharString(string first, string second)
        {
            if (String.IsNullOrEmpty(first) || String.IsNullOrEmpty(second))
            {
                throw new ArgumentException("String is null or empty");
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
