using System;
using Calculator.Operators;

namespace Calculator
{
    internal static class Calculator
    {
        private static ClassLibrary.Stack<double> stack;

        public static double Calculate(string expr)
        {
            if (String.IsNullOrEmpty(expr))
            {
                throw new ArgumentException("Null or empty string", nameof(expr));
            }

            stack = new ClassLibrary.Stack<double>(10);

            var entries = expr.Split(' ');

            foreach (var entry in entries)
            {
                ProcessEntry(entry);
            }

            if (stack.Count != 1)
            {
                throw new ArgumentException("Invalid expression. Numbers > operations.");
            }

            return stack.Pop();
        }

        private static void ProcessEntry(string entry)
        {
            if (Double.TryParse(entry, out var num))
            {
                stack.Push(num);
                return;
            }
            
            ProcessOperator(entry);
        }

        private static void ProcessOperator(string entry)
        {
            if (stack.Count < 2)
            {
                throw new ArgumentException("Invalid expression. Operations > numbers.");
            }

            var op = GetOperation(entry);
            op.PerformOperation(stack);
        }

        private static Operation GetOperation(string entry) => entry switch
        {
            "+" => new Addition() as Operation,
            "-" => new Subtraction() as Operation,
            "*" => new Multiplication() as Operation,
            "/" => new Division() as Operation,
            _ => throw new ArgumentException($"Invalid entry: {entry}")
        };
    }
}
