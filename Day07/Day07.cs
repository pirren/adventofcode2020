using AOC2020.Lib;
using System.Collections.Generic;
using System.IO;

namespace AOC2020.Solutions
{
    [ProblemName("x", "x")]
    class Day07 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-07.in");
        public string ProblemName { get => "Custom Customs"; }
        public string Day { get => "Day07"; }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        long PartTwo(string input)
        {
            return 0L;
        }

        long PartOne(string input)
        {
            return 0L;
        }
    }
}
