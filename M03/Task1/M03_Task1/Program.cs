using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace M03_Task1
{
    internal class Program
    {
        private const string AvgLengthInput = "test te";
        private const string DoubleCharFirst = "omg i love shrek";
        private const string DoubleCharSecond = "o kek";
        private const string SumFirst = "12250165209153784685228690083746175751559134784";
        private const string SumSecond = "1225016520915378468522869008374617575155";
        private const string ReverseInput = "test1 test2 test3";
        private static string inputFilePath = Path.Combine(Environment.CurrentDirectory, "Resources", "Text.txt");
        private static string outputFilePath = Path.Combine(Environment.CurrentDirectory, "Resources", "Numbers.txt");
        private static List<string> numbers = default;

        static void Main(string[] args)
        {
            try
            {
                var avgLength = AvgWordLength.GetAvgWordLength(AvgLengthInput);
                Console.WriteLine($"Avg length: {avgLength}");

                var doubledCharString = DoubleChars.GetDoubleCharString(DoubleCharFirst, DoubleCharSecond);
                Console.WriteLine($"Doubled string: {doubledCharString}");

                var sum = BigNumbersSum.Sum(SumFirst, SumSecond);
                Console.WriteLine($"Sum: {sum}");

                var reversed = ReverseWords.Reverse(ReverseInput);
                Console.WriteLine($"Reversed: {reversed}");
                
                using (var reader = new StreamReader(inputFilePath))
                {
                    var text = reader.ReadToEnd();
                    numbers = PhoneNumbers.GetNumbers(text).ToList();               
                }

                using (var writer = new StreamWriter(outputFilePath))
                {
                    foreach (var number in numbers)
                    {
                        writer.WriteLine(number);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}