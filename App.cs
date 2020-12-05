using AOC2020.Lib;
using AOC2020.Solutions;
using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2020.App
{
    class App
    {
        static void Main(string[] args)
        {
            var solvers = new List<ISolver> { new Day01(), new Day03(), new Day04() };
            var solver = new Day04();

            foreach (var solution in solver.Solve())
                Console.WriteLine(solution);

            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
    }
}
