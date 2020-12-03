using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020.Day03
{
    [ProblemName("Tobogan Trajectory", "Day03")]
    class Solution : ISolver
    {
        public IEnumerable<object> Solve(string input)
        {
            yield return PartOne(input);
            yield return PartTwo(input);
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
