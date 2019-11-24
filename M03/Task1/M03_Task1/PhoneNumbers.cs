using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace M03_Task1
{
    internal static class PhoneNumbers
    {
        public static IEnumerable<string> GetNumbers(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentException("String is null or empty", nameof(text));
            }

            var numbers = new List<string>();
            var regexes = new[] {
                new Regex(@"\+\d \(\d{3}\) \d{3}-\d{2}-\d{2}"),
                new Regex(@"\d \d{3} \d{3}-\d{2}-\d{2}"),
                new Regex(@"\+\d{3} \(\d{2}\) \d{3}-\d{4}")
            };

            foreach (var regex in regexes)
            {
                var matches = regex.Matches(text);

                foreach (var match in matches)
                {
                    numbers.Add(match.ToString());
                }
            }

            return numbers;
        }
    }
}
