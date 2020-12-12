using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020.Solutions
{
    public class Day09 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-09.in");
        public string ProblemName => "Encoding Error";
        public string Day => "Day09";

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        const int preamble = 25;

        long PartOne(string input) 
        {
            var (result, index) = FindAnomaly(input.Split(Environment.NewLine).Select(e => Int64.Parse(e)).ToArray());
            return result;
        }
        long PartTwo(string input)
        {
            var data = input.Split(Environment.NewLine).Select(e => Int64.Parse(e)).ToArray();
            var (anomaly, index) = FindAnomaly(data);
            var l = FindContiguousSet(data, anomaly);
            return l.Max() + l.Min();
        }

        (long,int) FindAnomaly(long[] data)
        {
            for (int i = preamble; i < data.Length; i++)
            {
                List<long> staged = new List<long>();
                for (int c = i - preamble; c < i; c++)
                    staged.Add(data[c]);
                if (!FindPair(staged, data[i]))
                    return (data[i], i);
            }
            return (-1L, -1);
        }

        bool FindPair(List<long> list, long target)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for(int j = 1; j < list.Count; j++)
                {
                    if (list[i] + list[j] == target && list[i] != list[j])
                        return true;
                }
            }
            return false;
        }

        List<long> FindContiguousSet(long[] data, long anomaly)
        {
            for (int i = 0; i < data.Length; i++)
            {
                List<long> check = new List<long>();
                for(int y = i; check.Sum() <= anomaly; y++)
                {
                    check.Add(data[y]);
                    if (check.Sum() == anomaly) return check;
                }
            }
            return new List<long>();
        }
    }
}
