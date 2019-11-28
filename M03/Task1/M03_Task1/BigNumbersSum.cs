using System;
using System.Linq;
using System.Text;

namespace M03_Task1
{
    internal static class BigNumbersSum
    {
        public static string Sum(string first, string second)
        {
            if (String.IsNullOrEmpty(first) || String.IsNullOrEmpty(second))
            {
                throw new ArgumentException(Resources.Resources.NullOrEmptyExMessage);
            }

            var sb = new StringBuilder();
            var firstLength = first.Length;
            var secondLength = second.Length;
            var max = Math.Max(firstLength, secondLength);
            var min = Math.Min(firstLength, secondLength);
            var delta = max - min;            
            int rem = 0, res = 0;
            char firstChar, secondChar;

            for (var i = max - 1; i >= 0; i--)
            {
                if (firstLength == max)
                {
                    firstChar = first[i];
                    secondChar = (i - delta >= 0) ? second[i - delta] : '0';
                }
                else
                {
                    firstChar = second[i];
                    secondChar = (i - delta >= 0) ? first[i - delta] : '0';
                }
                
                if (Int32.TryParse(firstChar.ToString(), out int firstNum) &&
                    Int32.TryParse(secondChar.ToString(), out int secondNum))
                {
                    res = firstNum + secondNum + rem;
                    rem = res / 10;
                    res %= 10;
                    sb.Append(res);
                }
                else
                {
                    throw new ArgumentException("Input string is not a correct number");
                }
            }
            if (rem > 0)
            {
                sb.Append(rem);
            }

            return new String(sb.ToString().Reverse().ToArray());
        }
    }
}
