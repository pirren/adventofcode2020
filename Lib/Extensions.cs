using System;
using System.Diagnostics;
using System.Linq;

namespace AOC2020.Lib
{
    static class Extensions
    {
        static Stopwatch Stopwatch { get; set; }
        public static void ProcessSolutions(this ISolver solver)
        {
            Write("\n========================================\n");
            Write($"Problem name: ");
            Write($"{ solver.ProblemName }\n", ConsoleColor.Red);
            Write($"Day: ");
            Write($"{solver.Day.Last()}\n\n", ConsoleColor.DarkRed);
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
            var i = 1;
            foreach (var solution in solver.Solve())
            {
                Console.WriteLine($"Part {i}: {solution}");
                i = 1 + i;
            }
            Stopwatch.Stop();
            Write($"\nFinished in {Stopwatch.ElapsedMilliseconds} ms"
                , (Stopwatch.ElapsedMilliseconds < 40) ? ConsoleColor.Green : ConsoleColor.Red);
            Write("\n========================================\n");
        }

        public static void Write(string text = "", ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
