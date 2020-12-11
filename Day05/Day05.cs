using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020.Solutions
{
    public class Day05 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-05.in");
        public string ProblemName => "Binary Boarding";
        public string Day => "Day05";

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        long PartOne(string data) => ParseSeats(data).Max();
        long PartTwo(string data)
        {
            var seats = ParseSeats(data).OrderBy(s => s);
            long found = seats.First();
            foreach (var seat in seats.Skip(1))
            {
                if (seat - found > 1)
                {
                    found = seat - 1;
                    break;
                }
                found = seat;
            }
            return found;
        }

        HashSet<int> ParseSeats(string data) =>
            data
                .Replace("F", "0")
                .Replace("B", "1")
                .Replace("L", "0")
                .Replace("R", "1")
                .Split(Environment.NewLine)
                .Select(e => Convert.ToInt32(e, 2))
                .ToHashSet();
    }
}
