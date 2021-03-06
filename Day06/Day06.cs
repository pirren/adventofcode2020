﻿using AOC2020.Lib;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020.Solutions
{
    public class Day06 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-06.in");
        public string ProblemName => "Custom Customs";
        public string Day => "Day06";

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        long PartTwo(string input)
        {
            var data = input.Split("\r\n");
            long sum = 0L;
            var index = 0;
            while (index < data.Length)
                sum += CollectiveAnswers(data, ref index);
            return sum;
        }

        long CollectiveAnswers(string[] data, ref int index)
        {
            string answers = "";
            int people = 0;
            while (index < data.Length && !string.IsNullOrWhiteSpace(data[index]))
            {
                answers += data[index];
                people++;
                index++;
            }
            index++;
            return answers.GroupBy(x => x).Where(x => x.Count() == people).Count();
        }

        long PartOne(string input)
        {
            var data = input.Split("\r\n");
            long sum = 0L;
            var index = 0;
            while (index < data.Length)
                sum += UniqueAnswers(data, ref index);
            return sum;
        }

        long UniqueAnswers(string[] data, ref int index)
        {
            string answers = "";
            while (index < data.Length && !string.IsNullOrWhiteSpace(data[index]))
            {
                answers += data[index];
                index++;
            }
            index++;
            return answers.Distinct().Count();
        }
    }
}
