using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Lib
{
    public class AppRunner
    {
        public bool Running { get; private set; }
        public string Input { get; set; }
        readonly List<string> killCommands = new List<string> { "q", "quit", "exit", "0" };

        private readonly List<Action> Actions;
        private readonly Dictionary<string, string> SystemStrings;
        public AppRunner(List<Action> actions, Dictionary<string, string> systemStrings)
        {
            SystemStrings = systemStrings;
            Actions = actions;
            Running = true;
        }

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
}
