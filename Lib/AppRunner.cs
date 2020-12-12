using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Lib
{
    public class AppRunner
    {
        public bool Active { get; private set; } = true;
        public string Input { get; private set; }

        readonly List<string> killCommands = new List<string> { "q", "quit", "exit", "0" };

        private readonly List<Action> actions;
        public AppRunner(List<Action> actions) => this.actions = actions;

        public void Start() => System.Write($"{System.Greeting}\n");

        public void Run()
        {
            System.Write($"{System.Actions(actions.Count)}\n", ConsoleColor.DarkGreen);
            if (int.TryParse(Input = Console.ReadLine(), out int choice))
                RunProblem(choice);
            if (Input.ToLower() == "a")
                RunAll();
            if (killCommands.Any(e => e == Input.ToLower()))
                Active = false;
        }

        private void RunAll()
        {
            foreach (Action a in actions)
                a.Invoke();
        }

        private void RunProblem(int choice)
        {
            if (choice <= actions.Count && choice > 0) actions[choice - 1].Invoke();
        }
    }
}
