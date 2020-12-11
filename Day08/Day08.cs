using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2020.Solutions
{
    public class Day08 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-08.in");
        public string ProblemName => "Handheld Halting";
        public string Day => "Day08";

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        long PartOne(string input)
        {
            program = input.Split(Environment.NewLine);
            var (result, _) = GetAccumulatorValue(program);
            return result;
        }

        static string[] program;

        long PartTwo(string input)
        {
            program = input.Split(Environment.NewLine);
            long acc = 0L;

            for (int i = 0; i < program.Length; i++)
            {
                var newprog = (string[])program.Clone();
                if (newprog[i].Substring(0, 3) == "nop")
                    newprog[i] = $"jmp {newprog[i][4..]}";
                else if (newprog[i].Substring(0, 3) == "jmp")
                    newprog[i] = $"nop {newprog[i][4..]}";
                var (result, clear) = GetAccumulatorValue(newprog, true);
                if (clear) { acc = result; break; }
            }
            return acc;
        }

        (long, bool) GetAccumulatorValue(string[] program, bool correct = false)
        {
            long acc = 0L;

            List<int> visited = new List<int>();
            int i = 0;
            while (i < program.Length)
            {
                if (visited.Contains(i)) { correct = false; break; }
                visited.Add(i);
                var instruction = program[i].Substring(0, 3);
                var value = int.Parse(program[i][4..]);
                if (instruction == "nop") { i++; continue; }
                if (instruction == "acc") { i++; acc += value; }
                if (instruction == "jmp") i += value;
            }
            return (acc, correct);
        }
    }
}
