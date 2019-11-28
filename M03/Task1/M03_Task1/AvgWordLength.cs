using System;
using System.Linq;

namespace M03_Task1
{
    internal static class AvgWordLength
    {
        public static double GetAvgWordLength(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Null or empty input string", nameof(input));
            }

            var separators = input.Where(c => !Char.IsLetter(c)).Distinct().ToArray();
            var splitInput = input.Split(separators).Where(w => w.Length > 0);

            if (!splitInput.Any())
            {
                throw new ArgumentException("No words in input string", nameof(input));
            }

            return splitInput.Average(w => w.Length);
        }
    }
}
