namespace Calculator
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var expr = "5 1 2 + 4 * + 3 -";

            var res = Calculator.Calculate(expr);
        }
    }
}
