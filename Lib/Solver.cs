using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AOC2020.Lib
{
    class ProblemName : Attribute
    {
        public readonly string name;
        public readonly string day;

        public ProblemName(string name, string day)
        {
            this.name = name;
            this.day = day;
        }
    }

    public interface ISolver
    {
        IEnumerable<object> Solve();
        string GetData { get; }
    }

    static class ISolverExtensions
    {
        static Stopwatch Stopwatch { get; set; }
        public static void Run(this ISolver solver)
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
            solver.Solve().ToList().ForEach(e => { Console.WriteLine($"Result: {e}"); });
            Stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Finished in {Stopwatch.ElapsedMilliseconds} ms");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
