using AOC2020.Lib;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace AOC2020.Solutions
{
    [ProblemName("Handheld Halting", "Day08")]
    class Day08 : ISolver
    {
        static Dictionary<string, List<string>> rules;
        public string GetData => File.ReadAllText("Indata/day-08.in");
        public string ProblemName { get => "Handheld Halting"; }
        public string Day { get => "Day08"; }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        long PartOne(string input)
        {
            long acc = 0L;
            program = input.Split(Environment.NewLine);

            List<int> visited = new List<int>();
            int i = 0;
            while(i < program.Length)
            {
                if (visited.Contains(i)) 
                    break;
                visited.Add(i);
                var instruction = program[i].Substring(0, 3);
                var value = int.Parse(program[i][4..]);
                if (instruction == "nop")
                {
                    i++;
                    continue;
                }
                if (instruction == "acc")
                {
                    i++;
                    acc += value;
                }
                if (instruction == "jmp")
                    i += value;
            }

            return acc;
        }

        static string[] program;
        long PartTwo(string input)
        {
            program = input.Split(Environment.NewLine);
            List<int> tried = new List<int>();
            var result = RecurseSolveLoop(program, ref tried);
            return result;
        }

        long RecurseSolveLoop(string[] program, ref List<int> tried)
        {
            long acc = 0L;

            int i = 0;
            while (i < program.Length)
            {
                var instruction = program[i].Substring(0, 3);
                var value = int.Parse(program[i][4..]);
                if (instruction == "nop")
                {
                    instruction = "jmp";
                }
                else if(instruction == "nop")
                {
                    i++;
                    continue;
                }
                if (instruction == "acc")
                {
                    i++;
                    acc += value;
                }
                if (instruction == "jmp")
                {
                    i++;
                    continue;
                }
                else 
                {
                    i += value;
                }
            }
            return acc;
        }
    }
}
