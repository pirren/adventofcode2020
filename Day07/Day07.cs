using AOC2020.Lib;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Solutions
{
    [ProblemName("Handy Haversacks", "Day07")]
    class Day07 : ISolver
    {
        static Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();
        public string GetData => File.ReadAllText("Indata/day-07.in");
        public string ProblemName { get => "Handy Haversacks"; }
        public string Day { get => "Day07"; }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            //yield return PartTwo(GetData);
        }

        void ParseRules(string[] bags)
        {
            foreach (var rule in bags)
            {
                var bagrules = rule.Replace(" bags", " bag").Replace(" bag", "")
                    .Split(new string[] { " contain ", ", ", "." }, StringSplitOptions.RemoveEmptyEntries);
                var values = new List<string>();
                for (int i = 1; i < bagrules.Length; i++)
                    values.Add(bagrules[i][2..]);
                if(bagrules[1] != "no other") rules.Add(bagrules[0], values);
            }
        }

        long PartOne(string input)
        {
            var bags = input.Split("\r\n");
            ParseRules(bags);
            return GetAllParents("shiny gold").Distinct().Count();
        }

        List<string> GetAllParents(string target)
        {
            var containers = GetImmediateParents(target);
            List<string> list = new List<string>(); 
            foreach(var container in containers)
            {
                list.Add(container);
                list.AddRange(GetAllParents(container));
            }
            return list;
        }

        List<string> GetImmediateParents(string target) => rules.Where(e => e.Value.Contains(target)).Select(s => s.Key).ToList();

        //}"long PartTwo(string input)
        //{

        //    return 0L;
        //}
    }
}
