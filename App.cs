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

            public AppRunner() => Running = true; 

            readonly List<string> quitCommands = new List<string> { "q", "quit", "exit" };

            public void Start() => Console.WriteLine(SystemStrings["greeting"]);

            public void Run()
            {
                Console.WriteLine(SystemStrings["actions"]);
                if (int.TryParse(Input = Console.ReadLine(), out int choice))
                    RunProblem(choice);
                if (Input.ToLower() == "a")
                    RunAll();
                if (Input.ToLower().Any(q => quitCommands.Contains(q.ToString()))) Running = false;
            }

            private void RunAll()
            {
                foreach (Action a in Actions)
                    a.Invoke();
            }

            private void RunProblem(int choice) 
            {
                if (choice < Actions.Count && choice > 0) Actions[choice - 1].Invoke();
            }
        }

        static readonly List<ISolver> Solvers = new List<ISolver>
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
        };

        static readonly List<Action> Actions = new List<Action>
        {
            new Action(Solvers[0].Run),
            new Action(Solvers[1].Run),
            new Action(Solvers[2].Run),
            new Action(Solvers[3].Run),
            new Action(Solvers[4].Run),
        };

        static Dictionary<string, string> SystemStrings = new Dictionary<string, string>
        {
            { "greeting","Advent of Code 2020 version"},
            { "actions","Enter a problem[1-25?], or [a] for all"},
        };
    }
}
