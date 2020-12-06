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
            var app = new AppRunner(Actions, SystemStrings);

            app.Start();
            while (app.Running) { app.Run(); }
        }

        static readonly List<ISolver> Solvers = new List<ISolver>
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
            new Day06(),
        };

        static readonly List<Action> Actions = new List<Action>
        {
            new Action(Solvers[0].ProcessSolutions),
            new Action(Solvers[1].ProcessSolutions),
            new Action(Solvers[2].ProcessSolutions),
            new Action(Solvers[3].ProcessSolutions),
            new Action(Solvers[4].ProcessSolutions),
            new Action(Solvers[5].ProcessSolutions),
        };

        public static Dictionary<string, string> SystemStrings = new Dictionary<string, string>
        {
            { "greeting","Advent of Code 2020 version"},
            { "actions","\nEnter a problem[1-25?], or [a] for all"},
        };
    }
}
