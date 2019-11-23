using System;

namespace M03_Task1
{
    internal class Program
    {
        private static string avgLengthInputStr = "";

        static void Main(string[] args)
        {
            try
            {
                var avgLength = AvgWordLength.GetAvgWordLength(avgLengthInputStr);
                Console.WriteLine($"Avg length: {avgLength}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
