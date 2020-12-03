using AOC2020.Lib;
using System;
using System.IO;

namespace AOC2020.App
{
    class App
    {
        static void Main(string[] args)
        {
            var solver = new AOC2020.Day03.Solution();

            foreach (var solution in solver.Solve(File.ReadAllText("Day03/input.in")))
                Console.WriteLine(solution);

            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
    }
}
