using AOC2020.Lib;
using AOC2020.Solutions;
using System;
using System.Collections.Generic;

namespace AOC2020.App
{
    class App
    {
        static void Main(string[] args)
        {
            AppRunner runner = new AppRunner(Actions);
            runner.Start();
            while (runner.Active) { runner.Run(); }
        }

        static readonly List<ISolver> Solvers = new List<ISolver>
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
            new Day06(),
            new Day07(),
            new Day08(),
            new Day09(),
        };

        static readonly List<Action> Actions = new List<Action>
        {
            new Action(Solvers[0].ProcessSolutions),
            new Action(Solvers[1].ProcessSolutions),
            new Action(Solvers[2].ProcessSolutions),
            new Action(Solvers[3].ProcessSolutions),
            new Action(Solvers[4].ProcessSolutions),
            new Action(Solvers[5].ProcessSolutions),
            new Action(Solvers[6].ProcessSolutions),
            new Action(Solvers[7].ProcessSolutions),
            new Action(Solvers[8].ProcessSolutions),
        };
    }
}
