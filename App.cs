using AOC2020.Lib;
using AOC2020.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AOC2020.App
{
    class App
    {
        static readonly List<ISolver> Solvers = new List<ISolver>
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04()
        };

        static readonly List<Action> Runners = new List<Action>
        {
            new Action(Solvers[0].Run),
            new Action(Solvers[1].Run),
            new Action(Solvers[2].Run),
            new Action(Solvers[3].Run),
        };

        static void Main(string[] args)
        {
            Console.WriteLine("AOC2020");
            var indata = Console.ReadLine();

            if (indata == ":w") Environment.Exit(0);
            Run(int.Parse(indata));

            Console.Write(Environment.NewLine);
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }

        static void Run(int day) => Runners[day - 1].Invoke();
    }
}
