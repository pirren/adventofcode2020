using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2020.Solutions
{
    [ProblemName("Binary Boarding", "Day05")]
    class Day05 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-05.in");
        public string ProblemName { get => "Binary Boarding"; }
        public string Day { get => "Day05"; }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        int PartOne(string data) => ParseSeats(data).Max();
        int PartTwo(string data) 
        {
            var seats = ParseSeats(data).OrderBy(s => s);
            var found = seats.First();
            foreach(var seat in seats.Skip(1))
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
