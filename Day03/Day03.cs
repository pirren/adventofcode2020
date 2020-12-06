using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020.Solutions
{
    [ProblemName("Tobogan Trajectory", "Day03")]
    class Day03 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-03.in");
        public string ProblemName { get => "Tobogan Trajectory"; }
        public string Day { get => "Day03"; }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        long PartOne(string input) => CalcSlope(input, (1, 3));
        long PartTwo(string input) => CalcSlope(input, (1, 1), (1, 3), (1, 5), (1, 7), (2, 1));

        long CalcSlope(string input, params (int down, int right)[] slopes)
        {
            var map = input.Split(Environment.NewLine);
            long treesEncountered = 1L;
            int mapWidth = map.First().Length;
            foreach (var (down, right) in slopes)
            {
                var (iright, idown) = (right, down);
                var trees = 0;
                while (idown < map.Length)
                {
                    if (map[idown][iright % mapWidth] == '#')
                        trees++;
                    (iright, idown) = (iright + right, idown + down);
                }
                treesEncountered *= trees;
            }
            return treesEncountered;
        }
    }
}
