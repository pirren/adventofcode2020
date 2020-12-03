using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Solutions
{
    public static class ThirdAdvent
    {
        internal static void Solve(string[] data)
        {
            throw new NotImplementedException();
        }

        private class TreeMapService
        {
            public TreeMap TreeMap { get; set; }
        }

        private class TreeMap
        {
            public List<string> Grid { get; private set; }

            public TreeMap(List<string> grid) => Grid = grid;
        }
    }

}
