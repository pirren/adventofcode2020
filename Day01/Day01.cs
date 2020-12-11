using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2020.Solutions
{
    public class Day01 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-01.in");
        public string ProblemName { get => "Report Repair"; }
        public string Day { get => "Day01"; }

        public IEnumerable<object> Solve()
        {
            yield return Solve(GetData, false);
            yield return Solve(GetData);
        }

        long Solve(string data, bool fullScope = true)
        {
            var entries = data.Split(Environment.NewLine);
            for (int i = 0; i < entries.Length; i++)
                for (int j = i + 1; j < entries.Length; j++)
                {
                    if (!fullScope)
                    {
                        if (int.Parse(entries[i]) + int.Parse(entries[j]) == 2020)
                            return int.Parse(entries[i]) * int.Parse(entries[j]);
                    }
                    else
                    {
                        for (int k = j + 1; k < entries.Length; k++)
                        {
                            if (int.Parse(entries[i]) + int.Parse(entries[j]) + int.Parse(entries[k]) == 2020)
                                return int.Parse(entries[i]) * int.Parse(entries[j]) * int.Parse(entries[k]);
                        }
                    }
                }
            return 0;
        }
    }
}
