using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Solutions
{
    [ProblemName("Password Philosophy", "Day02")]
    class Day02 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-02.in");
        public string ProblemName { get => "Password Philosophy"; }
        public string Day { get => "Day02"; }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        long PartOne(string data)
        {
            long passwords = 0L;
            var dataList = data.Split(Environment.NewLine);
            foreach (var pwRaw in dataList)
            {
                var pw = new Password(pwRaw);
                var uniques = pw.Phrase.Count(e => e == pw.Char);
                if (uniques >= pw.FirstNumber && uniques <= pw.SecondNumber) passwords++;
            }
            return passwords;
        }

        long PartTwo(string data)
        {
            long passwords = 0L;
            var dataList = data.Split(Environment.NewLine);
            foreach (var pwRaw in dataList)
            {
                var pw = new Password(pwRaw);
                var first = pw.Phrase[pw.FirstNumber - 1] == pw.Char;
                var second = pw.Phrase[pw.SecondNumber - 1] == pw.Char;

                if (first ^ second) passwords++;
            }
            return passwords;
        }

        class Password
        {
            public int FirstNumber { get; set; }
            public int SecondNumber { get; set; }
            public char Char { get; set; }
            public string Phrase { get; set; }
            private readonly string regexPattern = @"([0-9]{1,2})|[a-z]{1}(?=\:)";

            public Password(string rawData)
            {
                var matches = Regex.Matches(rawData, regexPattern);

                FirstNumber = int.Parse(matches[0].Value);
                SecondNumber = int.Parse(matches[1].Value);
                Char = matches[2].Value[0];
                Phrase = rawData.Split(": ")[1];
            }
        }
    }
}
