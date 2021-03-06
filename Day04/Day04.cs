﻿using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Solutions
{
    public class Day04 : ISolver
    {
        public string GetData => File.ReadAllText("Indata/day-04.in");
        public string ProblemName => "Passport Processing";
        public string Day => "Day04";

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        long PartOne(string input) => Part1(input);
        long PartTwo(string input) => Part2(input);

        readonly string[] labels = new string[] { @"byr:", @"iyr:", @"eyr:", @"hgt:", @"hcl:", @"ecl:", @"pid:" };

        long Part1(string input)
        {
            long validCount = 0L;
            var data = input.Split("\r\n\r\n");
            var pattern =
                string.Join("|", labels
                .Select(e => Regex.Escape(e)));
            for (int i = 0; i < data.Length; i++)
                if (Regex.Matches(data[i], pattern).Count >= 7) validCount++;
            return validCount;
        }

        long Part2(string input)
        {
            long validCount = 0L;

            var data = input.Split("\r\n\r\n");
            for (int i = 0; i < data.Length; i++)
                data[i] = data[i].Replace("\r\n", " ");

            for (int i = 0; i < data.Length; i++)
            {
                int validationPoints = 0;
                var fields = data[i].Split(' ');
                foreach (var field in fields)
                {
                    switch (field.Substring(0, 4))
                    {
                        case "byr:":
                            validationPoints += ValidateYear(field, 1920, 2002); break;
                        case "iyr:":
                            validationPoints += ValidateYear(field, 2010, 2020); break;
                        case "eyr:":
                            validationPoints += ValidateYear(field, 2020, 2030); break;
                        case "hgt:":
                            if (Regex.Match(field.Replace("hgt:", ""), @"^(59in|7[0-6]in|6[0-9]in)$|^(1[5-8][0-9]cm|^19[0-3]cm)$").Success)
                                validationPoints++;
                            break;
                        case "hcl:":
                            if (field.Replace("hcl:", "").Length == 7 && int.TryParse(field.Substring(5, 6), System.Globalization.NumberStyles.HexNumber, null, out _))
                                validationPoints++;
                            break;
                        case "ecl:":
                            if (new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(field.Substring(4, 3)))
                                validationPoints++;
                            break;
                        case "pid:":
                            if (field.Length == 13 && int.TryParse(field.Substring(4, 9), out _))
                                validationPoints++;
                            break;
                    }
                }
                if (validationPoints >= 7) validCount++;
            }
            return validCount;
        }

        int ValidateYear(string field, int min, int max)
        {
            if (int.TryParse(field.Substring(4, 4), out int n))
                if (max >= n && n >= min && field.Length == 8) return 1;
            return 0;
        }
    }
}
