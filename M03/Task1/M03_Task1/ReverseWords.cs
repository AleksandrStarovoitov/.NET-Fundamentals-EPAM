using System;
using System.Linq;

namespace M03_Task1
{
    internal static class ReverseWords
    {
        public static string Reverse(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("String is null or empty", nameof(input));
            }

            var splitInput = input.Split(' ').Reverse().ToArray();
            return String.Join(" ", splitInput);
        }
    }
}
