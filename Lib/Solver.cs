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
        string ProblemName { get; }
        string Day { get; }
    }

    static class ISolverExtensions
    {
        static Stopwatch Stopwatch { get; set; }
        public static void RunSolutions(this ISolver solver)
        {
            Write("\n===========================\n");
            Write($"Problem name: ");
            Write($"{ solver.ProblemName }\n\n", ConsoleColor.Red);
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
            solver.Solve().ToList().ForEach(e => { 
                Console.WriteLine($"Result: {e}"); 
            });
            Stopwatch.Stop();
            Write($"\nFinished in {Stopwatch.ElapsedMilliseconds} ms", ConsoleColor.Green);
            Write("\n===========================\n");
        }

        public static void Write(string text = "", ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
