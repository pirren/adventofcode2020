using AOC2020.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020.Solutions
{
    class Day02 : ISolver
    {

        public IEnumerable<object> Solve()
        {
            yield return PartOne(this.GetData());
            //yield return PartTwo(this.GetData());
        }
        public string GetData() => File.ReadAllText("Indata/day-02.in");


        long PartOne(string data)
        {
            long validPasswords = 0L;
            var pws = data.Split(Environment.NewLine);

            return validPasswords;
        }
    }
}
