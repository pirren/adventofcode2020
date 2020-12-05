using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        void Run();
        IEnumerable<object> Solve();
        string GetData();
    }

    static class ISolverExtensions
    {

    }
}
