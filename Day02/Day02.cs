using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2020.Solutions
{
    [ProblemName("Password Philosophy", "Day02")]
    class Day02 : ISolver
    {
        public void Run()
        {
            foreach (var solution in this.Solve())
                Console.WriteLine(solution);
        }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(this.GetData());
            yield return PartTwo(this.GetData());
        }

        public string GetData() => File.ReadAllText("Indata/day-02.in");

        long PartOne(string data)
        {
            long validPasswords = 0L;
            var dataList = data.Split(Environment.NewLine);
            foreach (var pwRaw in dataList)
            {
                var pw = new Password(pwRaw);
                var uniques = pw.Phrase.Count(e => e == pw.Char);
                if (uniques >= pw.FirstNumber && uniques <= pw.SecondNumber) validPasswords++;
            }
            return validPasswords;
        }

        long PartTwo(string data)
        {
            long validPasswords = 0L;
            var dataList = data.Split(Environment.NewLine);
            foreach (var pwRaw in dataList)
            {
                var pw = new Password(pwRaw);
                var first = pw.Phrase[pw.FirstNumber - 1] == pw.Char;
                var second = pw.Phrase[pw.SecondNumber - 1] == pw.Char;

                if (first ^ second)
                    validPasswords++;
            }
            return validPasswords;
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
