using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020.Solutions
{
    [ProblemName("Passport Processing", "Day04")]
    class Day04 : ISolver
    {
        public IEnumerable<object> Solve()
        {
            yield return PartOne(this.GetData());
            yield return PartTwo(this.GetData());
        }
        public string GetData() => File.ReadAllText("Indata/day-04.in");

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
            for(int i = 0; i < data.Length; i++)
                if (Regex.Matches(data[i], pattern).Count >= 7) validCount++;
            return validCount;
        }

        long Part2(string input)
        {
            long validCount = 0L;

            var data = input.Split("\r\n\r\n");
            for (int i = 0; i < data.Length; i++)
                data[i] = data[i].Replace("\r\n", " ");

            for (int i= 0; i < data.Length; i++)
            {
                int validationPoints = 0;
                var fields = data[i].Split(' ');
                foreach(var field in fields)
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
                            validationPoints += ValidHairColor(field); break;
                        case "ecl:":
                            if (new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(field.Substring(4, 3)))
                                validationPoints++;
                            break;
                        case "pid:":
                            if (field.Length != 13) break;
                            if (int.TryParse(field.Substring(4, 9), out _))
                                validationPoints++;
                            break;
                    }
                }
                if (validationPoints >= 7) validCount++;
            }

            return validCount;
        }

        int ValidHairColor(string field)
        {
            if (field.Replace("hcl:", "").Length != 7) return 0;
            try
            {
                var f = Int32.Parse(field.Substring(5, 6), System.Globalization.NumberStyles.HexNumber);
                return 1;
            } catch { return 0; }
        }

        int ValidateYear(string field, int min, int max)
        {
            if (field.Length != 8) return 0;
            try
            {
                var year = int.Parse(field.Substring(4, 4));
                if (max >= year && year >= min)
                    return 1;
                else return 0;
            }
            catch { return 0; }
        }
    }
}
