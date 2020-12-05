using System;
using System.Collections.Generic;

namespace AOC2020.Lib
{
    class ProblemName : Attribute
    {
        public readonly string name;
        public readonly string day;

        public ProblemName(string name, string day)
        {
            this.name = name;
            this.day = day;
        }
    }

    public interface ISolver
    {
        IEnumerable<object> Solve();
        string GetData();
        // todo: implement
        //IEnumerable<object> Test(string input);
    }

    static class ISolverExtensions
    {

    }
}
