using System;
using System.Diagnostics;

namespace Performance
{
    internal class Program
    {
        public static Random rnd;
        private const int ArraySize = 100000;

        private static void Main(string[] args)
        {
            rnd = new Random();

            C[] classes = null;
            S[] structs = null;

            var classDelta = GetPrivateMemoryDelta(() => {
                classes = new C[ArraySize];

                for (int i = 0; i < ArraySize; i++)
                {
                    classes[i] = new C(rnd.Next(Int32.MaxValue));
                }
            });
            Console.WriteLine($"PrivateMemorySize64 class delta: {classDelta}");

            var structDelta = GetPrivateMemoryDelta(() => {
                structs = new S[ArraySize];

                for (int i = 0; i < ArraySize; i++)
                {
                    structs[i].I = rnd.Next(Int32.MaxValue);
                }
            });
            Console.WriteLine($"PrivateMemorySize64 struct delta: {structDelta}");

            Console.WriteLine($"Class delta - struct delta: {classDelta - structDelta}");

            var structSortTime = GetExecutionTime(() =>
            {
                Array.Sort<S>(structs);
            });
            Console.WriteLine($"Struct sort time: {structSortTime}");

            var classSortTime = GetExecutionTime(() =>
            {
                Array.Sort<C>(classes);
            });
            Console.WriteLine($"Class sort time: {classSortTime}");
        }

        private static long GetPrivateMemoryDelta(Action action)
        {
            using (var procBefore = Process.GetCurrentProcess())
            {
                var memBefore = procBefore.PrivateMemorySize64;

                action();

                using (var procAfter = Process.GetCurrentProcess())
                {
                    var memAfter = procAfter.PrivateMemorySize64;
                    var delta = memAfter - memBefore;
                    return delta;
                }
            }
        }

        private static long GetExecutionTime(Action action)
        {
            var watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
