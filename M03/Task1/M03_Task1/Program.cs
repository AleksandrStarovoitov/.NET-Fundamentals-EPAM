using System;

namespace M03_Task1
{
    internal class Program
    {
        private static string avgLengthInputStr = "test test";

        static void Main(string[] args)
        {
            try
            {
                var avgLength = AvgWordLength.GetAvgWordLength(avgLengthInputStr);
                Console.WriteLine($"Avg length: {avgLength}");

                var doubledCharString = DoubleChars.GetDoubleCharString("omg i love shrek", "o kek");
                Console.WriteLine($"Doubled string: {doubledCharString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
