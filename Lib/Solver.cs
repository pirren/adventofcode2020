using System;
using System.Collections.Generic;

namespace AOC2020.Lib
{
    public interface ISolver
    {
        IEnumerable<object> Solve();
        string GetData { get; }
        string ProblemName { get; }
        string Day { get; }
    }
}
