using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2020.Lib
{
    class ProblemName : Attribute
    {
        public readonly string Name;
        public ProblemName(string name, string day)
        {
            this.Name = name;
        }
    }

    public interface ISolver
    {
        IEnumerable<object> Solve(string input);
    }

    static class ISolverExtensions
    {
        public static string GetInput(this ISolver solver)
        {
            return File.ReadAllText(@"input.in");
        } 
    }
}
