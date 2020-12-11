using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AOC2020.Lib
{
    static class SolverExtensions
    {
        public static void ProcessSolutions(this ISolver solver)
        {
            System.Write("\n========================================\n");
            System.Write($"Problem name: ");
            System.Write($"{ solver.ProblemName }\n", ConsoleColor.Red);
            System.Write($"Day: ");
            System.Write($"{solver.Day.Last()}\n\n", ConsoleColor.DarkRed);
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();
            var i = 1;
            foreach (var solution in solver.Solve())
            {
                System.Write($"Part {i}: {solution}\n");
                i = 1 + i;
            }
            Stopwatch.Stop();
            System.Write($"\nFinished in {Stopwatch.ElapsedMilliseconds} ms"
                , (Stopwatch.ElapsedMilliseconds < 40) ? ConsoleColor.Green : ConsoleColor.Red);
            System.Write("\n========================================\n");
        }
    }

    public static class ListExtensions
    {
        public static T PopAt<T>(this List<T> list, int index)
        {
            T r = list[index];
            list.RemoveAt(index);
            return r;
        }

        public static T PopLast<T>(this List<T> list)
        {
            T r = list.LastOrDefault();
            list.RemoveAt(list.Count() - 1);
            return r;
        }
    }
}
