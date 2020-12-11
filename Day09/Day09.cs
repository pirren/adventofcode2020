using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2020.Solutions
{
    public class Day09 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-09.in");
        public string ProblemName { get => "Encoding Error"; }
        public string Day { get => "Day09"; }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        const int preamble = 25;

        long PartOne(string input)
        {
            var res = 0L;
            var program = input.Split(Environment.NewLine);

            List<string> ls = new List<string>();
            var f = ls.PopAt(0);

            return res;
        }

        long PartTwo(string input)
        {
            long res = 0L;
            var program = input.Split(Environment.NewLine);


            return res;
        }

    }
}
