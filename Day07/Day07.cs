using AOC2020.Lib;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace AOC2020.Solutions
{
    class Day07 : ISolver
    {
        static Dictionary<string, List<string>> rules;
        public string GetData => File.ReadAllText("Indata/day-07.in");
        public string ProblemName { get => "Handy Haversacks"; }
        public string Day { get => "Day07"; }

        public IEnumerable<object> Solve()
        {
            yield return PartOne(GetData);
            yield return PartTwo(GetData);
        }

        void ParseRules(string[] bags)
        {
            foreach (var rule in bags)
            {
                var bagrules = rule.Replace(" bags", " bag").Replace(" bag", "")
                    .Split(new string[] { " contain ", ", ", "." }, StringSplitOptions.RemoveEmptyEntries);
                var values = new List<string>();
                for (int i = 1; i < bagrules.Length; i++)
                    values.Add(bagrules[i]);
                if(bagrules[1] != "no other") rules.Add(bagrules[0], values);
            }
        }

        long PartOne(string input)
        {
            rules = new Dictionary<string, List<string>>();
            var bags = input.Split("\r\n");
            ParseRules(bags);
            return CountContainers("shiny gold").Distinct().Count();
        }

        long PartTwo(string input)
        {
            rules = new Dictionary<string, List<string>>();
            var bags = input.Split("\r\n");
            ParseRules(bags);
            return CountBags("shiny gold");
        }

        List<string> GetParents(string target) => rules
            .Where(e => e.Value.Select(e => e[2..]).Contains(target))
            .Select(s => s.Key).ToList();

        List<string> CountContainers(string target)
        {
            var containers = GetParents(target);
            List<string> list = new List<string>();
            foreach (var container in containers)
            {
                list.Add(container);
                list.AddRange(CountContainers(container));
            }
            return list;
        }
        List<string> GetBags(string target) 
            => rules
            .Where(e => e.Key == target)
            .Select(s => s.Value).FirstOrDefault();

        long CountBags(string target) 
        {
            long count = 0L;
            var bags = GetBags(target); 
            if (bags == null) return count;

            foreach(var bag in bags)
            {
                int childCount = int.Parse(bag[0].ToString());
                count += childCount * CountBags(bag[2..]);
            }
            count += bags.Select(s => int.Parse(s[0].ToString())).Sum();

            return count;
        }
    }
}
