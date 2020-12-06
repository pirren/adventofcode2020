using AOC2020.Lib;
using AOC2020.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.App
{
    class App
    {
        static void Main(string[] args)
        {
            var app = new AppRunner();

            app.Start();
            while (app.Running) { app.Run(); }
        }

        class AppRunner
        {
            public bool Running { get; private set; }
            public string Input { get; set; }
            readonly List<string> killCommands = new List<string> { "q", "quit", "exit", "0" };

            public AppRunner() => Running = true; 


            public void Start() => Console.WriteLine(SystemStrings["greeting"]);

            public void Run()
            {
                Console.WriteLine(SystemStrings["actions"]);
                if (int.TryParse(Input = Console.ReadLine(), out int choice))
                    RunProblem(choice);
                if (Input.ToLower() == "a")
                    RunAll();
                if (killCommands.Any(e => e.Contains(Input.ToLower()))) Running = false;
            }

            private void RunAll()
            {
                foreach (Action a in Actions)
                    a.Invoke();
            }

            private void RunProblem(int choice) // set to pvt in production
            {
                if (choice <= Actions.Count && choice > 0) Actions[choice - 1].Invoke();
            }
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
            new Action(Solvers[0].RunSolutions),
            new Action(Solvers[1].RunSolutions),
            new Action(Solvers[2].RunSolutions),
            new Action(Solvers[3].RunSolutions),
            new Action(Solvers[4].RunSolutions),
            new Action(Solvers[5].RunSolutions),
        };

        static Dictionary<string, string> SystemStrings = new Dictionary<string, string>
        {
            { "greeting","Advent of Code 2020 version"},
            { "actions","\nEnter a problem[1-25?], or [a] for all"},
        };
    }
}
